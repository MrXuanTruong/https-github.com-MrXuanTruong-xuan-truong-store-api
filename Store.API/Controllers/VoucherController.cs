using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataTables.Queryable;
using Store.Entity.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using DataTables.AspNet.Core;
using AutoMapper;
using Store.API.Controllers;
using Store.Services;
using Store.API.Models;
using Store.API.Models.Operator;
using Store.Services.Helpers;
using Store.Entity.Criteria;
using Store.API.Models.Brand;
using Store.API.Models.Voucher;
using Store.Services.EmailServices;
using Store.API.Services;

namespace Store.Api.Controllers
{
    public class VoucherController : AdminBaseController
    {
        private readonly IViewRenderService _viewRenderService;
        private readonly IVoucherService _voucherService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<VoucherController> _logger;

        private readonly IEmailService _emailService;

        public VoucherController(
            IVoucherService voucherService,
            IMapper mapper,
            IEmailService emailService,
            IAccountService accountService,
            IViewRenderService viewRenderService,
            ILogger<VoucherController> logger)
        {
            _voucherService = voucherService;
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _viewRenderService = viewRenderService;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        // For Datatable
        [HttpGet("")]
        public dynamic GetList([FromQuery] VoucherCriteriaModel criteria, [FromQuery] IDataTablesRequest request)
        {
            try
            {
                //var query = _accountService.GetByCriteria(criteria);
                var query = _voucherService.GetAll();
                if (!string.IsNullOrEmpty(criteria.VoucherCode))
                {
                    query = query.Where(x => x.VoucherCode == criteria.VoucherCode);
                }

                if (criteria.FromStartDate.HasValue)
                {
                    query = query.Where(x => x.StartDate >= criteria.FromStartDate);
                }

                if (criteria.ToStartDate.HasValue)
                {
                    query = query.Where(x => x.StartDate <= criteria.ToStartDate);
                }

                if (criteria.FromEndDate.HasValue)
                {
                    query = query.Where(x => x.EndDate >= criteria.FromEndDate);
                }

                if (criteria.ToEndDate.HasValue)
                {
                    query = query.Where(x => x.EndDate <= criteria.ToEndDate);
                }

                var brands =
                    query
                    .Select(x => new VoucherRequestModel
                    {
                        VoucherId = x.VoucherId,
                        VoucherCode = x.VoucherCode,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Price = x.Price,
                        CustomerName = x.Account.FullName,
                        Email = x.Account.Email,
                    })
                    .ToList()
                    .AsQueryable();

                var filteredData = brands;

                return ToDataTableResponse<VoucherRequestModel>(filteredData, request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.GetType().Name);
                return ToDataTableResponse<VoucherRequestModel>();
            }
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpGet("{id:int}")]
        public async Task<API.Models.Voucher.VoucherRequestModel> GetById(int id)
        {
            API.Models.Voucher.VoucherRequestModel response;
            var voucher = await _voucherService.GetById(id);
            if (voucher != null)
            {
                response = new VoucherRequestModel
                {
                    VoucherId = (long)voucher.VoucherId,
                    VoucherCode = voucher.VoucherCode,
                    StartDate = voucher.StartDate,
                    EndDate = voucher.EndDate,
                    Price = voucher.Price
                };
            }
            else
            {
                response = new VoucherRequestModel
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3),
                };
            }

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel> Delete(int id)
        {
            var response = new ResponseViewModel
            {
                Result = true,
            };

            response.Result = await _voucherService.Detete(id);
            response.Messages.Add(response.Result ? SuccessMessage : FailMessage);

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPost]
        public async Task<ResponseViewModel> Create(int id,[FromBody] API.Models.Voucher.VoucherRequestModel model)
        {
            var oldVoucher = await _voucherService.GetById(id);
            if (oldVoucher != null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Mã voucher đã tồn tại");

                return response;
            }
            else
            {
                var voucherCode = $"KM{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}";
                var voucher = new Voucher
                {
                    VoucherCode = voucherCode,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    IsDeleted = 0,
                    Price = model.Price,
                    AccountId = model.AccountId,
                    IsUsed = 0,
                };

                ApplyUserCreateEntity(voucher);

                return await CreateVoucher(voucher);
            }
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel> Update(int id, [FromBody] VoucherRequestModel model)
        {
            var voucher = await _voucherService.GetById(id);
            if (voucher == null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Không tìm thấy voucher");

                return response;
            }

            voucher.StartDate = model.StartDate;
            voucher.EndDate = model.EndDate;
            voucher.Price = model.Price;
            
            ApplyUserUpdateEntity(voucher);

            return await CreateVoucher(voucher);
        }

        private async Task<ResponseViewModel> CreateVoucher(Voucher voucher)
        {
            var response = new ResponseViewModel
            {
                Result = true,
            };

            response.Result = voucher.VoucherId <= 0 ? await _voucherService.Insert(voucher) : await _voucherService.Update(voucher);
            if (response.Result == false)
            {
                response.Messages.Add($"Thao tác không thành công");
            }
            else
            {
                response.RefObjectId = voucher.VoucherId;

                // send email

                var account = await _accountService.GetById(voucher.AccountId);
                voucher.Account = account;
                var subject = "Bạn có 1 Voucher";
                var bodyHtml = await _viewRenderService.RenderToStringAsync<Voucher>("EmailTemplates/VoucherEmailTemplate", voucher);
                var alias = "";
                await _emailService.Send(subject, bodyHtml, alias, new List<string>() { account.Email });
            }

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [AllowAnonymous]
        [HttpGet("GetByVoucherCode")]
        public async Task<VoucherByCodeModel> GetByVoucherCode(string voucherCode)
        {
            voucherCode = voucherCode.ToUpper();
            VoucherByCodeModel response = new VoucherByCodeModel
            {
                Result = false,
            };

            var voucher = 
                _voucherService.GetAll()
                .Where(x=>x.VoucherCode == voucherCode && x.IsDeleted == 0 && x.IsUsed == 0)
                .FirstOrDefault();


            if (voucher != null)
            {
                if(voucher.StartDate > DateTime.Now || voucher.EndDate < DateTime.Now)
                {
                    response.Messages.Add($"Mã voucher đã hết hạn sử dụng");
                }
                else
                {
                    response.Result = true;
                    response.Price = voucher.Price;
                }
            }
            else
            {
                response.Messages.Add($"Mã voucher không tồn tại");
            }

            return response;
        }


    }

}
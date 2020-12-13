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

namespace Store.Api.Controllers
{
    public class OperatorController : AdminBaseController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<OperatorController> _logger;
        public OperatorController(
            IAccountService accountService, 
            IMapper mapper,
            ILogger<OperatorController> logger)
        {
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        // For Datatable
        [HttpGet("GetList")]
        public dynamic GetList([FromQuery]OperatorCriteriaModel criteria, [FromQuery]IDataTablesRequest request)
        {
            try
            {
                //var query = _accountService.GetByCriteria(criteria);
                var query = _accountService.GetAll();
                var operators =
                    query
                    .Select(x => new OperatorRequestModel
                    {
                        Id = x.AccountId,
                        Username = x.Username,
                        Fullname = x.FullName,
                        Address = x.Address,
                        Email = x.Email,
                        Password = x.Password,
                        Phone = x.Phone,
                        AccountStatusId = x.AccountStatusId,
                        AccountTypeId = x.AccountTypeId,
                        BranchId = x.BranchId,
                        AccountTypeName = x.AccountType.AccountTypeName,
                        AccountStatusName = x.AccountStatus.AccountStatusName,
                        BranchName = x.Branch.BranchName,

                    })
                    .ToList()
                    .AsQueryable();

                var filteredData = operators;

                return ToDataTableResponse<OperatorRequestModel>(filteredData, request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.GetType().Name);
                return ToDataTableResponse<OperatorRequestModel>();
            }
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpGet("{id:int}")]
        public async Task<OperatorRequestModel> GetById(int id)
        {
            OperatorRequestModel response;
            var account = await _accountService.GetById(id);
            if (account != null)
            {
                response = new OperatorRequestModel
                {
                    Id = account.AccountId,
                    Fullname = account.FullName,
                    Username = account.Username,
                    Email = account.Email,
                    Phone = account.Phone,
                    AccountTypeId = account.AccountTypeId,
                    AccountStatusId = account.AccountStatusId,
                    BranchId = account.BranchId,
                    Address = account.Address,
                    DateOfBirth = account.DateOfBirth,
                    AccountStatusName = account.AccountStatus?.AccountStatusName,
                    AccountTypeName = account.AccountType?.AccountTypeName,
                    BranchName = account.Branch?.BranchName,
                };
            }
            else
            {
                response = new OperatorRequestModel
                {
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

            response.Result = await _accountService.Detete(id);
            response.Messages.Add(response.Result ? SuccessMessage : FailMessage);

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPost]
        public async Task<ResponseViewModel> Create([FromBody]OperatorRequestModel model)
        {
            var oldOperator = await _accountService.GetByUsername(model.Username);
            if (oldOperator != null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Tên tài khoản hoặc email đã tồn tại");

                return response;
            }
            else
            {
                var account = new Account
                {
                    Username = model.Username,
                    FullName = model.Fullname,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    AccountTypeId=model.AccountTypeId,
                    AccountStatusId=model.AccountStatusId,
                    BranchId=model.BranchId,
                    Password = Encryptor.MD5Hash(model.Password),

                };

                ApplyUserCreateEntity(account);

                return await SaveOrUpdate(account);
            }
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel> Update(int id, [FromBody]OperatorRequestModel model)
        {
            var oper = await _accountService.GetById(id);
            if (oper == null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Không tìm thấy tài khoản");

                return response;
            }

            oper.FullName = model.Fullname;
            oper.Email = model.Email;
            oper.Phone = model.Phone;
            oper.Address = model.Address;
            oper.AccountTypeId = model.AccountTypeId;
            oper.AccountStatusId = model.AccountStatusId;
            oper.BranchId = model.BranchId;
            oper.DateOfBirth = model.DateOfBirth;
            if (!string.IsNullOrEmpty(model.Password))
            {
                oper.Password = Encryptor.MD5Hash(model.Password);
            }

            ApplyUserUpdateEntity(oper);

            return await SaveOrUpdate(oper);
        }

        private async Task<ResponseViewModel> SaveOrUpdate(Account account)
        {
            var response = new ResponseViewModel
            {
                Result = true,
            };

            response.Result = account.AccountId <= 0? await _accountService.Insert(account) : await _accountService.Update(account);
            if (response.Result == false)
            {
                response.Messages.Add($"Thao tác không thành công");
            }
            else
            {
                response.RefObjectId = account.AccountId;
            }

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        //[HttpGet("{id:int}/privileges")]
        //public async Task<IActionResult> GetPrivileges(int id)
        //{
        //    var response = new PrivilegeResponseModel
        //    {
        //        Result = true
        //    };

        //    var allPrivileges = parameter.OperatorBll.Privileges().ToList();
        //    var assignedPrivileges = await parameter.OperatorBll.PrivilegeOfOperator(id);

        //    response.Privileges = allPrivileges.Select(x => 
        //        new PrivilegeModel
        //        {
        //            PrivilegeId = x.PrivilegeId,
        //            PrivilegeName = x.PrivilegeName,
        //            Assigned = assignedPrivileges.Any(y => y.PrivilegeId == x.PrivilegeId)
        //        })
        //        .ToList();

        //    return Ok(response);
        //}

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        //[HttpPut("{id:int}/privileges")]
        //public async Task<IActionResult> UpdatePrivileges(int id, [FromBody] List<Privilege> privileges)
        //{
        //    var response = new PrivilegeResponseModel
        //    {
        //        Result = true
        //    };

        //    var assignedPrivileges = await parameter.OperatorBll.PrivilegeOfOperator(id);

        //    var removePrivileges = assignedPrivileges.Where(x => privileges.Any(y => y.PrivilegeId == x.PrivilegeId) == false).ToList();
        //    var addPrivileges = privileges.Where(x => assignedPrivileges.Any(y => y.PrivilegeId == x.PrivilegeId) == false).ToList();

        //    await parameter.OperatorBll.ApplyPrivilege(id, addPrivileges, removePrivileges);

        //    return Ok(response);
        //}
    }
}
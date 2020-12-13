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
using Store.API.Models.Account;

namespace Store.API.Controllers
{
    public class RegisterController : AdminBaseController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterController> _logger;
        public RegisterController(
            IAccountService accountService,
            IMapper mapper,
            ILogger<RegisterController> logger)
        {
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;
        }

        //[HttpGet("{id:int}")]
        //public async Task<OperatorRequestModel> GetById(int id)
        //{
        //    OperatorRequestModel response;
        //    var account = await _accountService.GetById(id);
        //    if (account != null)
        //    {
        //        response = new OperatorRequestModel
        //        {
        //            Id = account.AccountId,
        //            Fullname = account.FullName,
        //            Username = account.Username,
        //            Email = account.Email,
        //            Phone = account.Phone,
        //            AccountTypeId = account.AccountTypeId,
        //            AccountStatusId = account.AccountStatusId,
        //            BranchId = account.BranchId,
        //            Address = account.Address,
        //            DateOfBirth = account.DateOfBirth,
        //            AccountStatusName = account.AccountStatus?.AccountStatusName,
        //            AccountTypeName = account.AccountType?.AccountTypeName,
        //            BranchName = account.Branch?.BranchName,
        //        };
        //    }
        //    else
        //    {
        //        response = new OperatorRequestModel
        //        {
        //        };
        //    }

        //    return response;
        //}
        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseViewModel> Create([FromBody] RegisterRequestModel model)
        {
            var oldOperator = await _accountService.GetByUsername(model.Username);
            if (oldOperator != null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Email đã tồn tại");

                return response;
            }
            else
            {
                var account = new Account
                {
                    Username = model.Email,
                    FullName = model.Fullname,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    AccountTypeId = 3,
                    AccountStatusId = 1,
                    Password = Encryptor.MD5Hash(model.Password),

                };

                ApplyUserCreateEntity(account);

                return await Save(account);
            }
        }
        
            private async Task<ResponseViewModel> Save(Account account)
            {
                var response = new ResponseViewModel
                {
                    Result = true,
                };

                response.Result = account.AccountId <= 0 ? await _accountService.Insert(account) : await _accountService.Update(account);
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
        }
    }


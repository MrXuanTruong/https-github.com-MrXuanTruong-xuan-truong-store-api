using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Store.API.Infrastructure;
using Store.API.Models.Account;
using Store.Entity.Domains;
using Store.Services;

namespace Store.API.Controllers
{
    public class AccountController : AdminBaseController
    {
        private readonly ILogger<AccountController> _logger;

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;

        public AccountController(
            IMapper mapper,
            IConfiguration configuration,
            IAccountService accountService,
            ILogger<AccountController> logger)
        {
            _mapper = mapper;
            _accountService = accountService;
            _configuration = configuration;
            _logger = logger;
    }

        [AllowAnonymous]
        [HttpPost("login")] //api/account/login
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {
            var response = new LoginResponseModel()
            {

            };

            var account = await _accountService.Authenticate(model.Username, model.Password);

            if (account == null)
            {
                response.Result = false;
                response.Messages.Add("Thông tin đăng nhập không đúng");
            }
            else
            {
                var permissions = new List<string>(); // Danh sach quyền của user. sau này sẽ bổ xung sau
                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = _configuration.GetValue<string>("AppSettings:JWTSecret");
                var expiredInMinute = _configuration.GetValue<int>("AppSettings:TokenExpiredInMinute");
                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimType.Id, account.AccountId.ToString()),
                        new Claim(ClaimType.Email, account.Email == null? "" : account.Email),
                        new Claim(ClaimType.Username, account.Username),
                        new Claim(ClaimType.Fullname, account.FullName),
                        new Claim(ClaimType.Permissions, JsonConvert.SerializeObject(permissions)), // Permissions -> Json
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiredInMinute),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                foreach (var permission in permissions)
                {
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, permission));
                }

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var access_token = tokenHandler.WriteToken(token);

                response.Result = true;
                response.AccessToken = access_token;
                response.ExpiredDate = tokenDescriptor.Expires;
            }

            return await Task.FromResult(Ok(response));
        }

        [HttpGet("me")]
        public CurrentAccountResponseModel GetCurrentUser()
        {
            var account = CurrentUser;
            var response = _mapper.Map<CurrentAccountResponseModel>(account);
            return response;
        }

        [HttpGet("")]
        public List<Account> GetAllAccount()
        {
            var accounts = _accountService.GetAll().ToList();
            return accounts;
        }
    }
}

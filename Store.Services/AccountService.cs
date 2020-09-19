﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Entity;
using Store.Entity.Domains;
using Store.Services.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly ILogger<AccountService> _logger;

        public AccountService(DatabaseContext context,
            ILogger<AccountService> logger) : 
            base(context)
        {
            _logger = logger;
        }

        public Task<Account> Authenticate(string username, string password)
        {
            var hashPassword = Encryptor.MD5Hash(password);
            return context.Accounts
                .Where(x => x.Username.ToLower() == username.ToLower() && x.Password == hashPassword)
                .FirstOrDefaultAsync();
        }

        public IQueryable<Account> GetAll()
        {
            return context.Accounts.AsNoTracking();
        }

        public async Task<bool> Detete(long id)
        {
            var result = true;
            try
            {
                var account = await GetById(id);
                context.Accounts.Remove(account);
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(AccountService));
            }

            return result;
        }

        public Task<Account> GetById(long id)
        {
            return context.Accounts
                .Where(x => x.AccountId == id)
                .Include(x => x.CreatedAccount)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(Account entity)
        {
            var result = true;
            try
            {
                await context.Accounts.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(AccountService));
            }

            return result;
        }

        public bool Update(Account entity)
        {
            var result = true;
            try
            {
                context.Accounts.Update(entity);
                context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(AccountService));
            }

            return result;
        }
    }
}

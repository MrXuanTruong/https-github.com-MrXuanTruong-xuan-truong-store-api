using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Entity;
using Store.Entity.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class VoucherService : BaseService, IVoucherService
    {
        private readonly ILogger<VoucherService> _logger;

        public VoucherService(DatabaseContext context,
            ILogger<VoucherService> logger) :
            base(context)
        {
            _logger = logger;
        }

        public IQueryable<Voucher> GetAll()
        {
            return 
                context.Vouchers
                .Include(x => x.Account)
                .Where(x => x.IsDeleted == 0)
                .AsNoTracking();
        }

        public async Task<bool> Detete(long id)
        {
            var result = true;
            try
            {
                var voucher = await GetByIdWithoutInclude(id);
                voucher.IsDeleted = 1;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(BrandService));
            }

            return result;

        }

        public Task<Voucher> GetById(long id) => context.Vouchers
                .Include(x => x.Account)
                .Where(x => x.VoucherId == id && x.IsDeleted == 0)
                .SingleOrDefaultAsync();

        public Task<Voucher> GetByIdWithoutInclude(long id)
        {
            return context.Vouchers
                .Where(x => x.VoucherId == id && x.IsDeleted == 0)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(Voucher voucher)
        {
            var result = true;
            try
            {
                voucher.IsDeleted = 0;

                await context.Vouchers.AddAsync(voucher);
                await context.SaveChangesAsync();

                context.Entry(voucher);
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(VoucherService));
            }

            return result;

        }

        public async Task<bool> Update(Voucher entity)
        {
            var result = true;
            try
            {
                context.Vouchers.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(VoucherService));
            }

            return result;
        }


    }
}

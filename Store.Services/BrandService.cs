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
    public class BrandService : BaseService, IBrandService
    {
        private readonly ILogger<BrandService> _logger;

        public BrandService(DatabaseContext context,
            ILogger<BrandService> logger) :
            base(context)
        {
            _logger = logger;
        }

        public IQueryable<ProductBrand> GetAll()
        {
            return 
                context.ProductBrands
                .Include(x => x.Products)
                .Where(x => x.IsDeleted == 0)
                .AsNoTracking();
        }

        public async Task<bool> Detete(long id)
        {
            var result = true;
            try
            {
                var product = await GetByIdWithoutInclude(id);
                product.IsDeleted = 1;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(BrandService));
            }

            return result;

        }

        public Task<ProductBrand> GetById(long id)
        {
            return context.ProductBrands
                .Include(x => x.Products)
                .Where(x => x.ProductBrandId == id && x.IsDeleted == 0)
                .SingleOrDefaultAsync();
        }

        public Task<ProductBrand> GetByIdWithoutInclude(long id)
        {
            return context.ProductBrands
                .Where(x => x.ProductBrandId == id && x.IsDeleted == 0)
                .SingleOrDefaultAsync();

        }

        public async Task<bool> Insert(ProductBrand productBrand)
        {
            var result = true;
            try
            {
                productBrand.IsDeleted = 0;

                await context.ProductBrands.AddAsync(productBrand);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(BrandService));
            }

            return result;

        }

        public async Task<bool> Update(ProductBrand entity)
        {
            var result = true;
            try
            {
                context.ProductBrands.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(BrandService));
            }

            return result;
        }


    }
}

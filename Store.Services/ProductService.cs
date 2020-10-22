using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Entity;
using Store.Entity.Domains;
using Store.Services.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly ILogger<IProductService> _logger;

        public ProductService(DatabaseContext context,
            ILogger<ProductService> logger) :
            base(context)
        {
            _logger = logger;
        }

        //public Task<Account> Authenticate(string username, string password)
        //{
        //    var hashPassword = Encryptor.MD5Hash(password);
        //    return context.Accounts
        //        .Where(x => x.Username.ToLower() == username.ToLower() && x.Password == hashPassword)
        //        .FirstOrDefaultAsync();
        //}

        public IQueryable<Product> GetAll()
        {
            return context.Products.AsNoTracking();
        }

        public async Task<bool> Detete(long id)
        {
            var result = true;
            try
            {
                var product = await GetById(id);
                context.Products.Remove(product);
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(ProductService));
            }

            return result;
        }

        public Task<Product> GetById(long id)
        {
            return context.Products
                .Where(x => x.ProductId == id)
                .Include(x => x.CreatedProduct)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(Product entity)
        {
            var result = true;
            try
            {
                await context.Products.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(ProductService));
            }

            return result;
        }

        public async Task<bool> Update(Product entity)
        {
            var result = true;
            try
            {
                context.Products.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(ProductService));
            }

            return result;
        }

        public Task<Product> GetByProductName(string product)
        {
            return context.Products.Where(x => x.ProductName == product).FirstOrDefaultAsync();
        }

        public Task<Product> GetById(string productname)
        {
            throw new NotImplementedException();
        }

        Task IProductService.GetByProductName(string productName)
        {
            throw new NotImplementedException();
        }
    }
}

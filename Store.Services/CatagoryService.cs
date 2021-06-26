using Microsoft.EntityFrameworkCore;
using Store.Entity;
using Store.Entity.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class CatagoryService : BaseService, ICatagoryService
    {
        public CatagoryService(DatabaseContext context): base(context)
        {
        }

        public Task<List<AccountType>> AccountTypes()
        {
            return context.AccountTypes.AsNoTracking().ToListAsync();
        }
        public Task<List<Branch>> Branches()
        {
            return context.Branches.AsNoTracking().ToListAsync();
        }
        public Task<List<AccountStatus>> AccountStatuses()
        {
            return context.AccountStatuses.AsNoTracking().ToListAsync();
        }
        public Task<List<ProductStatus>> ProductStatuses()
        {
            return context.ProductStatuses.AsNoTracking().ToListAsync();
        }

        public Task<List<Category>> Categories()
        {
            return context.Categories.AsNoTracking().ToListAsync();
        }

        public Task<List<ProductBrand>> Brands()
        {
            return context.ProductBrands.AsNoTracking().ToListAsync();
        }

        public Task<List<Color>> Colors()
        {
            return context.Colors.AsNoTracking().ToListAsync();
        }

        public Task<List<ProductColor>> ColorsByProductId(long productId)
        {
            return context.ProductColors.Include(x =>x.Color).Where(x=>x.ProductId == productId).AsNoTracking().ToListAsync();
        }

        public Task<List<OrderStatus>> OrderStatuses()
        {
            return context.OrderStatuses.AsNoTracking().ToListAsync();
        }

        public Task<List<Order>> GetOrderConfirmeds()
        {
            return context.Orders.Where(x=>x.OrderStatusId == 2).AsNoTracking().ToListAsync();
        }

        public Task<List<Order>> GetOrderPaids()
        {
            return context.Orders.Where(x => x.OrderStatusId == 3).AsNoTracking().ToListAsync();
        }
    }
}

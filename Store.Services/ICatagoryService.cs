using Store.Entity.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface ICatagoryService: IBaseService
    {
        public Task<List<AccountType>> AccountTypes();
        public Task<List<Branch>> Branches();
        public Task<List<AccountStatus>> AccountStatuses();

        public Task<List<ProductStatus>> ProductStatuses();

        public Task<List<Category>> Categories();
        public Task<List<ProductBrand>> Brands();

        public Task<List<Color>> Colors();

        public Task<List<ProductColor>> ColorsByProductId(long productId);

        public Task<List<OrderStatus>> OrderStatuses();

        public Task<List<Order>> GetOrderConfirmeds();

        public Task<List<Order>> GetOrderPaids();
    }
}

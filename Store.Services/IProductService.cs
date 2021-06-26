using Store.Entity.Domains;
using Store.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface IProductService :
        IBaseService,
        IAddEntity<Product>,
        IUpdateEntity<Product>,
        IDeleteEntity,
        IGetEntityById<Product>

    {

        Task<Product> GetByIdWithoutInclude(long id);

        IQueryable<Product> GetAll();

        Task<List<Branch>> GetStoreAvailableForProductId(long id);
        Task<List<ProductImage>> GetImagesForProductId(long id);

        IQueryable<Product> NewestProducts(int take);

        IQueryable<Product> ProductByCategory(int take);

        IQueryable<Product> SellingProducts(int take);

        IQueryable<Product> FeatureProducts(int take);

        List<Product> SimilarProducts(long id);

        List<ProductBranch> GetProductBranchesByProductId(long productId);

        Task<bool> InStocks(long branchId, string note, List<long> productIds, List<long> colorIds, List<int> quantities, List<double> prices);

        Task<bool> OutStocks(
            long branchId,
            long orderId,
            string note,
            List<long> productIds,
            List<long?> colorIds,
            List<int> quantities,
            List<double> prices
            );
    }
}

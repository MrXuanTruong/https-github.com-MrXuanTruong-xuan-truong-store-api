using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Entity;
using Store.Entity.Domains;
using Store.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly ILogger<ProductService> _logger;

        public ProductService(DatabaseContext context,
            ILogger<ProductService> logger) :
            base(context)
        {
            _logger = logger;
        }

        public IQueryable<Product> GetAll()
        {
            return
                context.Products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductStatus)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductBranchs)
                .Include(x => x.ProductImages)
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
                //context.Products.Remove(product);
                await context.SaveChangesAsync();
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
                .Include(x => x.ProductImages)
                .Include(x => x.Category)
                .Include(x => x.ProductStatus)
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .Include(x => x.ProductBranchs)
                .ThenInclude(x => x.Branch)
                .Include(x => x.ProductBranchs)
                .ThenInclude(x => x.Color)
                .Where(x => x.ProductId == id && x.IsDeleted == 0 )
                //.AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public Task<Product> GetByIdWithoutInclude(long id)
        {
            return context.Products
                .Where(x => x.ProductId == id && x.IsDeleted == 0)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(Product product)
        {
            var result = true;
            try
            {
                product.IsDeleted = 0;

                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();

                foreach (var productColor in product.ProductColors)
                {
                    productColor.ProductId = product.ProductId;
                    if (productColor.ProductColorId <= 0)
                    {
                        await context.ProductColors.AddAsync(productColor);
                    }
                    else
                    {
                        context.ProductColors.Update(productColor);
                    }
                }

                await context.SaveChangesAsync();

                foreach (var productImage in product.ProductImages)
                {
                    productImage.ProductId = product.ProductId;
                    if (productImage.ProductImageId <= 0)
                    {
                        await context.ProductImages.AddAsync(productImage);
                    }
                    else
                    {
                        context.ProductImages.Update(productImage);
                    }
                }
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

                foreach (var productColor in entity.ProductColors)
                {
                    productColor.ProductId = entity.ProductId;
                    if (productColor.ProductColorId <= 0)
                    {
                        await context.ProductColors.AddAsync(productColor);
                    }
                    else
                    {
                        context.ProductColors.Update(productColor);
                    }
                }
                await context.SaveChangesAsync();

                // databaseImages la tat ca hinh cua product id hien tai
                var databaseImages = await context.ProductImages.Where(x => x.ProductId == entity.ProductId).ToListAsync();

                // Xóa những tấm hình User xóa.
                var deleteImages = databaseImages.Where(x => !entity.ProductImages.Any(y => y.ProductImageUrl == x.ProductImageUrl));

                // Nhung hinh se Tao moi
                var addImages = entity.ProductImages.Where(x => !databaseImages.Any(y => y.ProductImageUrl == x.ProductImageUrl));

                // Nhung hinh Update thi khong lam gi. Boi vi update ko xay ra
                // User chi xoa va chon hinh moi ma thoi

                foreach (var image in deleteImages)
                {
                    context.ProductImages.Remove(image);
                }

                foreach (var productImage in addImages)
                {
                    productImage.ProductId = entity.ProductId;
                    await context.ProductImages.AddAsync(productImage);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(ProductService));
            }

            return result;
        }

        public IQueryable<Product> NewestProducts(int take)
        {
            return
                context.Products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductStatus)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductBranchs)
                .Include(x => x.ProductImages)
                .Where(x=>x.IsDeleted == 0)
                .OrderByDescending(x => x.CreatedDate)
                //.Skip(0)
                .Take(take)
                .AsNoTracking();
        }

        public IQueryable<Product> ProductByCategory(int take)
        {
            return
                context.Products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductStatus)
                .Include(x => x.ProductColors)
                .Include(x => x.Category)
                .Include(x => x.ProductBranchs)
                .Include(x => x.ProductImages)
                .Where(x => x.IsDeleted == 0)
                .AsNoTracking();
        }

        public IQueryable<Product> SellingProducts(int take)
        {
            var query = @"select * 
                            from 
	                            products 
                            where 
	                            ProductId in (
	                            SELECT Products.ProductId--, SUM(Quantity) TotalQuantity
	                            FROM Products
	                            INNER JOIN OrderDetails ON OrderDetails.ProductId = Products.ProductId
	                            GROUP BY Products.ProductId having SUM(Quantity) = 
	                            (
		                            select MAX(temp.TotalQuantity) MaxQuantity from 
		                            (
			                            SELECT Products.ProductId, SUM(Quantity) TotalQuantity
			                            FROM Products
			                            INNER JOIN OrderDetails ON OrderDetails.ProductId = Products.ProductId
			                            GROUP BY Products.ProductId
		                            ) as temp
	                            )
                            )";
            return context.Products.FromSqlRaw(query);
            //return
            //    context.Products
            //    .Include(x => x.ProductBrand)
            //    .Include(x => x.ProductStatus)
            //    .Include(x => x.ProductColors)
            //    .Include(x => x.ProductBranchs)
            //    .Include(x => x.ProductImages)
            //    .Where(x => x.IsDeleted == 0)
            //    .OrderByDescending(x => x.CreatedDate)
            //    //.Skip(0)
            //    .Take(take)
            //    .AsNoTracking();

        }

        public IQueryable<Product> FeatureProducts(int take)
        {
            return
                context.Products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductStatus)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductBranchs)
                .Include(x => x.ProductImages)
                .Where(x => x.IsDeleted == 0)
                .OrderByDescending(x => x.ViewCount)
                .Take(take)
                .AsNoTracking();
        }

        public List<Product> SimilarProducts(long id)
        {
            var product = context.Products.Find(id);
            if (product != null)
            {
                // ProductColors nó tiếp tục tham chiếu đến Color nên cứ Include tiếp Color để lấy
                return
                    context.Products
                    .Include(x => x.ProductBrand)
                    .Include(x => x.Category)
                    .Include(x => x.ProductStatus)
                    .Include(x => x.ProductColors)
                    .ThenInclude(y => y.Color)
                    .Include(x => x.ProductBranchs)
                    .Include(x => x.ProductImages)
                    .Where(x => x.ProductId != id && x.CategoryId == product.CategoryId && x.IsDeleted == 0)
                    .ToList();
            }
            else
            {
                // Return ko cos phan tu nao
                return new List<Product>();
            }
        }

        

        public async Task<bool> InStocks(long branchId, string note, List<long> productIds, List<long> colorIds, List<int> quantities, List<double> prices)
        {
            var result = false;

            try
            {
                var branch = context.Branches.Where(x => x.BranchId == branchId).FirstOrDefault();

                var importStock = new ImportStock
                {
                    CreatedDate = DateTime.Now,
                    ImportStockCode = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    BranchId = branch.BranchId,
                    Description = note,
                };

                await context.ImportStocks.AddAsync(importStock);
                await context.SaveChangesAsync();

                var totalquantity = 0;
                for (var i = 0; i < colorIds.Count; i++)
                {
                    var importStockDetail = new ImportStockDetail
                    {
                        ProductId = productIds[i],
                        ColorId = colorIds[i],
                        ImportStockId = importStock.ImportStockId,
                        Quantity = quantities[i],
                        Price = prices[i]
                    };

                    await context.ImportStockDetails.AddAsync(importStockDetail);
                    await context.SaveChangesAsync();

                    var productId = productIds[i];
                    var colorId = colorIds[i];

                    var productBranch =
                        context.ProductBranches
                        .Where(x => x.ProductId == productId && x.BranchId == branchId && x.ColorId == colorId)
                        .FirstOrDefault();

                    if (productBranch == null)
                    {
                        productBranch = new ProductBranch
                        {
                            ColorId = colorIds[i],
                            BranchId = branchId,
                            ProductId = productId,
                            LocalStock = quantities[i],
                        };

                        await context.ProductBranches.AddAsync(productBranch);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        productBranch.LocalStock += quantities[i];
                        context.ProductBranches.Update(productBranch);
                        await context.SaveChangesAsync();
                    }

                    totalquantity += quantities[i];
                }

                result = true;
            }
            catch(Exception ex)
            {
                result = false;
            }

            return result;
        }

        public async Task<bool> OutStocks(
            long branchId,
            long orderId,
            string note,
            List<long> productIds,
            List<long?> colorIds,
            List<int> quantities,
            List<double> prices
            )
        {
            var result = false;

            try
            {
                //var branch = context.Branches.Where(x => x.BranchId == branchId).FirstOrDefault();

                var exportStock = new ExportStock
                {
                    ExportStockCode = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Note = note,
                    OrderId = orderId,
                    FromBranchId = branchId,
                    CreatedDate = DateTime.UtcNow,
                };

                await context.ExportStocks.AddAsync(exportStock);
                await context.SaveChangesAsync();

                for (var i = 0; i < colorIds.Count; i++)
                {
                    var exportStockDetail = new ExportStockDetail
                    {
                        ProductId = productIds[i],
                        ColorId = colorIds[i],
                        ExportStockId = exportStock.ExportStockId,
                        Quantity = quantities[i],
                        Price = prices[i],

                    };

                    await context.ExportStockDetails.AddAsync(exportStockDetail);
                    await context.SaveChangesAsync();

                    var productId = colorIds[i];
                    var colorId = colorIds[i];

                    var productBranch =
                        context.ProductBranches
                        .Where(x => x.ProductId == productId && x.BranchId == branchId && x.ColorId == colorId)
                        .FirstOrDefault();

                    if (productBranch != null)
                    {
                        // trừ kho
                        productBranch.LocalStock -= quantities[i];
                        context.ProductBranches.Update(productBranch);
                        await context.SaveChangesAsync();
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }


        public IQueryable<Product> ProductDetails(int take)
        {
            return
                context.Products
                .Include(x => x.ProductName)
                .Include(x => x.Price)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductImages)
                .Where(x=> x.IsDeleted == 0)
                .OrderByDescending(x => x.CreatedDate)
                //.Skip(0)
                .Take(take)
                .AsNoTracking();
        }

        public Task<List<Branch>> GetStoreAvailableForProductId(long id)
        {
            return context.ProductBranches
                .Include(x => x.Branch)
                .Where(x => x.ProductId == id)
                .Select(x => x.Branch)
                .ToListAsync();
        }

        public Task<List<ProductImage>> GetImagesForProductId(long id)
        {
            return context.ProductImages
                .Where(x => x.ProductId == id)
                .ToListAsync();
        }
        public List<ProductBranch> GetProductBranchesByProductId(long productId)
        {
                return context.ProductBranches
                    .Include( x => x.Branch)
                    .Where(x => x.ProductId == productId)
                    .ToList();
        }
    }
}

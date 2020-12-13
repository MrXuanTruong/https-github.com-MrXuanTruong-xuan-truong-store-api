using Store.Entity.Domains;
using Store.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface IBrandService :
        IBaseService,
        IAddEntity<ProductBrand>,
        IUpdateEntity<ProductBrand>,
        IDeleteEntity,
        IGetEntityById<ProductBrand>

    {
        Task<ProductBrand> GetById(long productBrandId);
        Task<ProductBrand> GetByProductBrandName(string ProductBrandName);
        IQueryable<ProductBrand> GetAll();
    }
}

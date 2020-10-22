using Store.Entity.Domains;
using Store.Services.Interfaces;
using System;
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
        //Task<Product> Authenticate(string username, string password);

        Task<Product> GetById(string productname);

        IQueryable<Product> GetAll();
        Task GetByProductName(string productName);
    }
}

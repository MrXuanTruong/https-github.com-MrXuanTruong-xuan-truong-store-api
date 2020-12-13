using Store.Entity.Domains;
using Store.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface IOrderService :
        IBaseService,
        IAddEntity<Order>,
        IUpdateEntity<Order>,
        IDeleteEntity,
        IGetEntityById<Order>
    {
        public Task<List<Order>> Orders();
        IQueryable<Order> GetAll();

    }
}

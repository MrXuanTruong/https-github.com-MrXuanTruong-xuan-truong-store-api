using Store.Entity.Domains;
using Store.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface IVoucherService :
        IBaseService,
        IAddEntity<Voucher>,
        IUpdateEntity<Voucher>,
        IDeleteEntity,
        IGetEntityById<Voucher>

    {
        Task<Voucher> GetByIdWithoutInclude(long id);
        IQueryable<Voucher> GetAll();

    }
}

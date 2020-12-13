using AutoMapper;
using Store.API.Models;
using Store.API.Models.Account;
using Store.API.Models.Operator;
using Store.Entity.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.AutoMappers
{
    public class OperatorItemProfile : Profile
    {
        public OperatorItemProfile()
        {
            CreateMap<Account, OperatorItemModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AccountId));
        }
    }
}

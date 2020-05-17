/// <summary>
/// Author: Meghnath Das
/// Description: Extension for DI Registration
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL.Configuration
{
    using AutoMapper;
    using MD.Accountella.DataTransferObjects;
    using MD.Accountella.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public sealed class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EntityCategory, EntityCategoryDto>().AfterMap((src, dest) =>
            {
                dest.SubCategories = dest.SubCategories.Any() ? dest.SubCategories : null;
            });
            CreateMap<EntityCategoryDto, EntityCategory>();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Ledger, LedgerDto>().ReverseMap();
            CreateMap<AccTxn, AccTxnDto>().ReverseMap();
        }
    }
}

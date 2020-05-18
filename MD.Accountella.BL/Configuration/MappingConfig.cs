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
            CreateMap<AccTxn, AccTxnDto>();
            CreateMap<AccTxnDto, AccTxn>()
                .ForMember(dest => dest.LedgerEntries,
                    opt => opt.MapFrom<LedgerEntryCollectionResolver>());
        }
        private class LedgerEntryCollectionResolver : IValueResolver<AccTxnDto, AccTxn, Ledger[]>
        {
            public Ledger[] Resolve(AccTxnDto source, AccTxn dest, Ledger[] member, ResolutionContext context)
            {
                var lstLdgrEntries = new List<Ledger> { 
                    new Ledger
                    {
                        _AccountId = source._OnAccountId,
                        Amount = source.
                    }
                };

                return lstLdgrEntries.ToArray();
            }
        }
    }
}

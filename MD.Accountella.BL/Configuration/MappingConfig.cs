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
    using System.Text;
    public sealed class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EntityCategory, EntityCategoryDto>().ReverseMap();
            //CreateMap<EntityCategory, EntityCategoryDto>().AfterMap((src, dest) => { 
            //    src.ForModule
            //});
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}

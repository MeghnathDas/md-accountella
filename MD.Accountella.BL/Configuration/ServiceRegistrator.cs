/// <summary>
/// Author: Meghnath Das
/// Description: Extension for DI Registration
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL.Configuration
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddTransient<INavMenuService, NavMenuService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IEntityCategoryService, EntityCategoryService>();

            return services;
        }
    }
}

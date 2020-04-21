/// <summary>
/// Author: Meghnath Das
/// Description: Extension for DI Registration
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL.Configuration
{
    using Microsoft.Extensions.DependencyInjection;
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<INavMenuService, NavMenuService>();
            services.AddTransient<IAccounts, Accounts>();

            return services;
        }
    }
}

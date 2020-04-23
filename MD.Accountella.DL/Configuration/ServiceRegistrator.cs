/// <summary>
/// Author: Meghnath Das
/// Description: Extension for DI Registration
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistrator
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddSingleton<AccountellaDbContext>();
            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<IAccountManager, AccountManager>();

            return services;
        }
    }
}

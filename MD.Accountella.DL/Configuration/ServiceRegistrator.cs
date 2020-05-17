/// <summary>
/// Author: Meghnath Das
/// Description: Extension for DI Registration
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL.Configuration
{
    using MD.Accountella.Core.MongoDb.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistrator
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddSingleton<AccountellaDbContext>();
            services.AddTransient<IAccountsRepository, AccountsRepository>();
            services.AddTransient<IEntityCategoryRepository, EntityCategoryRepository>();
            services.AddTransient<IAccountTransactionRepository, AccountTransactionRepository>();
            services.AddTransient<ICurrencyTypeRepository, CurrencyTypeRepository>();

            return services;
        }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description: Extension for DI Registration
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL.Configuration
{
    using Microsoft.Extensions.DependencyInjection;
    using MD.Accountella.DL.Core;

    public static class ServiceRegistrator
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddSingleton<IDynamoDBStore, DynamoDBStore>();
            services.AddTransient<IAccountManager, AccountManager>();

            return services;
        }
    }
}

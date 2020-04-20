/// <summary>
/// Author: Meghnath Das
/// Description: Navigation menu related business logics
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL.Configuration
{
    using Microsoft.Extensions.DependencyInjection;
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountManager, AccountManager>();

            return services;
        }
    }
}

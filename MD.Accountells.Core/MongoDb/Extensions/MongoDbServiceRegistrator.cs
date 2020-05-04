/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb.Extensions.DependencyInjection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public static class MongoDbServiceRegistrator
    {
        public static IServiceCollection AddMongoDbConfigServices(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoConfig = configuration.GetSection("MongoDbConfig").Get<MongoDbConfig>();

            if (mongoConfig == null)
                mongoConfig = new MongoDbConfig
                {
                    ConnectionString = configuration.GetValue<string>("MONGO_CONNECTIONSTRING"),
                    DataBaseName = configuration.GetValue<string>("MONGO_DBNAME")
                };

            // Explicitly register the settings object
            services.AddSingleton<IMongoDbConfig>(mongoConfig);

            return services;
        }
    }
}

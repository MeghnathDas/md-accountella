/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using System;
    using System.Linq;
    using System.Reflection;
    using MD.Accountella.Core.MongoDb;
    using MD.Accountella.DomainObjects;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public class AccountellaDbContext : DbContext
    {
        private readonly ILogger _logger;
        public AccountellaDbContext(IMongoDbConfig mongoDbConfig, ILogger<AccountellaDbContext> logger) : base(mongoDbConfig)
        {
            _logger = logger;

            EventHandler<DbContextActionMessage> writeLog = (sender, e) =>
            {
                switch (e.MessageType)
                {
                    case DbContextActionMessageType.Info:
                        _logger.LogInformation(e.Text);
                        break;
                    case DbContextActionMessageType.Error:
                        _logger.LogError(e.Text);
                        break;
                    case DbContextActionMessageType.Warning:
                        _logger.LogWarning(e.Text);
                        break;
                }
            };

            OnMessaging += writeLog;
        }

        public override void OnModelCreating(EntityBuilder entityBuilder)
        {
            entityBuilder.UseSeedData<CurrencyType, CurrencyTypeSeedDataProvider>();
            entityBuilder.UseSeedData<EntityCategory, EntityCategorySeedDataProvider>();
            entityBuilder.UseSeedData<Account, AccountSeedDataProvider>();
        }
    }
}

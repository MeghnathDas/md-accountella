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
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using MD.Accountella.Core.DynamoDb;
    using MD.Accountella.DomainObjects;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public class AccountellaDbContext : DbContext
    {
        private readonly ILogger _logger;
        public AccountellaDbContext(IAmazonDynamoDB client, ILogger<AccountellaDbContext> logger) : base(client)
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

            if (!this.EnsureCreated())
                throw new Exception("Databse table creation failed");
        }

        public override void OnModelCreating(EntityBuilder entityBuilder)
        {
            entityBuilder.IncludeAllAvailableEntities();
            entityBuilder.Entity<EntityCategory>(new EntityCategorySeedDataProvider());
            entityBuilder.Entity<Account>(new AccountSeedDataProvider());
            entityBuilder.Entity<CurrencyType>(new CurrencyTypeSeedDataProvider());            
        }
    }
}

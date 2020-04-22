/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using System;
    using Amazon.DynamoDBv2;
    using MD.Accountella.Core.DynamoDb;
    using MD.Accountella.DomainObjects;
    using Microsoft.Extensions.Configuration;
    public class AccountellaDbContext : DbContext
    {
        public AccountellaDbContext(IAmazonDynamoDB client, IConfiguration config) : base(client)
        {
            if (!EnsureCreated())
                throw new Exception("Databse table creation failed");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>();
            modelBuilder.Entity<AccountCategory>();
            modelBuilder.Entity<AppUser>();
            modelBuilder.Entity<CurrencyType>();
            modelBuilder.Entity<Ledger>();
        }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using Amazon.DynamoDBv2;
    using System;

    public interface IDbContext
    {
        public event EventHandler<DbContextActionMessage> OnMessaging;
        public IAmazonDynamoDB Client { get; }
        public bool EnsureCreated();
    }
}

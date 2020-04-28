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
        event EventHandler<DbContextActionMessage> OnMessaging;
        IAmazonDynamoDB Client { get; }
        bool EnsureCreated();
    }
}

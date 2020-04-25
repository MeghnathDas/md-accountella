/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single Account
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using Amazon.DynamoDBv2.DataModel;

    internal class DbMigration
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string CreatedOn { get; set; }
        public string sourceApp { get; set; }
    }
}


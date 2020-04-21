/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL.Core
{
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    public interface IDynamoDBStore
    {
        public AmazonDynamoDBClient Client { get; }
        public DynamoDBContext DBContext { get; }
    }
}

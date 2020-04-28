/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataProcessor
    {
        BatchWrite GetBatchWrite(DynamoDBContext dbContext);

    }
}

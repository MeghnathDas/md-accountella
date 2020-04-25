/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using Amazon.DynamoDBv2.DataModel;
    using System.Threading.Tasks;
    public interface IExecuter
    {
        public Task Execute(DynamoDBContext dbContext);
    }
}

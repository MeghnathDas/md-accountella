/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataProcessor
    {
        Task ExecuteAsync(IMongoDatabase dbContext);

    }
}

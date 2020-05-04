/// <summary>
/// Author: Meghnath Das
/// Description: Extension for DI Registration
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    internal class MongoDbConfig: IMongoDbConfig
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
    public interface IMongoDbConfig
    {
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}

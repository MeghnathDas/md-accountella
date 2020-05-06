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

        internal const string Environment_ConnectionStringKey = "MONGO_CONNECTIONSTRING";
        internal const string Environment_DbNameKey = "MONGO_DBNAME";
    }
    public interface IMongoDbConfig
    {
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}

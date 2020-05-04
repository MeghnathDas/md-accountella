/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using System.Collections.Generic;
    internal class DbTableWithSeedInfo: DbTableInfo
    {
        public DbTableWithSeedInfo()
        {

        }
        public DbTableWithSeedInfo(DbTableInfo dbTableInfo)
        {
            this.tableName = dbTableInfo.tableName;
            this.attributes = dbTableInfo.attributes;
        }
        public IReadOnlyCollection<IDataProcessor> SeedDataProviders { get; set; }
    }
}

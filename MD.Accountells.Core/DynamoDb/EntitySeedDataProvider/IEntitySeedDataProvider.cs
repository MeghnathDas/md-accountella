/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using System;
    using System.Collections.Generic;

    public interface IEntitySeedDataProvider<TEntity> : IDataProcessor
    {
        public void SetDataToDelete(List<TEntity> data);
        public void SetDataToCreateOrUpdate(List<TEntity> data);
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IEntitySeedDataProvider<TEntity> : IDataProcessor
    {
        void SetArgumentToDelete(Expression<Func<TEntity, bool>> deletePredicate);
        void SetDataToCreate(List<TEntity> data);
    }
}

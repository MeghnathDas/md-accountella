/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class EntitySeedDataProvider<TEntity> : IEntitySeedDataProvider<TEntity>
    {

        private List<TEntity> _data_to_create;
        private Expression<Func<TEntity, bool>> _delPredicate;
        public EntitySeedDataProvider()
        {
            _delPredicate = null;
            _data_to_create = new List<TEntity>();
            SetArgumentToDelete(this._delPredicate);
            SetDataToCreate(this._data_to_create);
        }

        public virtual void SetArgumentToDelete(Expression<Func<TEntity, bool>> deletePredicate)
        {

        }
        public virtual void SetDataToCreate(List<TEntity> data)
        {

        }

        public Task ExecuteAsync(IMongoDatabase dbContext)
        {
            Task result = Task.CompletedTask;
            var entityColl = dbContext.GetCollection<TEntity>(typeof(TEntity).Name);

            var tasks = new List<Task>();
            if (_data_to_create.Any())
                tasks.Add(entityColl.BulkUpsert<TEntity>(_data_to_create));

            if (_delPredicate != null)
                tasks.Add(entityColl.DeleteManyAsync<TEntity>(_delPredicate));

            if (tasks.Count == 2)
            {
                result = tasks.First().ContinueWith(ct =>
                 {
                     if (ct.IsCompleted)
                     {
                         tasks.Last();
                     }
                 });
            }
            else if (tasks.Count == 1)
            {
                result = tasks.First();
            }

            return result;
        }

    }
}

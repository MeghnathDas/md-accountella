/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class EntitySeedDataProvider<TEntity> : IEntitySeedDataProvider<TEntity>
    {
        
        private List<TEntity> _data_to_Delete;
        private List<TEntity> _data_to_Put;
        public EntitySeedDataProvider()
        {
            _data_to_Delete = new List<TEntity>();
            _data_to_Put = new List<TEntity>();
            SetDataToDelete(this._data_to_Delete);
            SetDataToCreateOrUpdate(this._data_to_Put);
        }

        public abstract void SetDataToDelete(List<TEntity> data);
        public abstract void SetDataToCreateOrUpdate(List<TEntity> data);
        public Task ExecuteAsync(IMongoDatabase dbContext)
        {
            var entityColl = dbContext.GetCollection<TEntity>(nameof(TEntity));
            // entityColl.DeleteMany();
            return entityColl.InsertManyAsync(_data_to_Put);
        }
    }
}

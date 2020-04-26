/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using Amazon.DynamoDBv2.Model;

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
        public BatchWrite GetBatchWrite(DynamoDBContext dbContext)
        {
            var entityBatch = dbContext.CreateBatchWrite<TEntity>();

            if (_data_to_Delete.Any())
                entityBatch.AddPutItems(_data_to_Delete);

            if (_data_to_Put.Any())
                entityBatch.AddPutItems(_data_to_Put);

            return entityBatch;
        }
    }
}

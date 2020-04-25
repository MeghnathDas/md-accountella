/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;

    public abstract class EntitySeedDataProvider<TEntity> : IEntitySeedDataProvider<TEntity>
    {
        private readonly List<TEntity> _data;
        public EntitySeedDataProvider()
        {
            _data = new List<TEntity>();
            SetData(this._data);
        }

        public abstract void SetData(List<TEntity> data);

        public Task Execute(DynamoDBContext dbContext)
        {
            List<TEntity> extItems = new List<TEntity>();
            if (_data.Any())
                extItems = getEntities(dbContext);



            var tasks = _data.Select(dta => Task.Run(
                            () => dbContext.SaveAsync<TEntity>(dta)
                        ));

            return Task.WhenAll(tasks);
        }

        private List<TEntity> getEntities(DynamoDBContext dbContext)
        {
            var seedIdentities = getSeedDataIdentities();

            //Getting an Student object
            List<ScanCondition> conditions = new List<ScanCondition>();
            conditions.Add(
                new ScanCondition(seedIdentities.First().Key,
                    ScanOperator.Contains,
                    seedIdentities.Select(kv => kv.Value).ToArray())
                );

            return dbContext.ScanAsync<TEntity>(conditions).GetRemainingAsync().Result;
        }

        private KeyValuePair<string, string>[] getSeedDataIdentities()
        {
            return _data.Select(x =>  x.GetType().GetProperties()
                    .FirstOrDefault(tf => tf.GetCustomAttributes(typeof(DynamoDBHashKeyAttribute), true).Length > 0))
                    .Select(hk =>
                            new KeyValuePair<string, string>(hk == null ? "id" : hk.Name,
                                (string)hk.GetValue(typeof(TEntity), null))
                        )
                    .ToArray();
        }
    }
}

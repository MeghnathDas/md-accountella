/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public class EntityBuilder: IEntityBuilder
    {
        private Dictionary<Type, List<IDataProcessor>> _dicTyps;
        private DbTableWithSeedInfo convertTableInfo(KeyValuePair<Type, List<IDataProcessor>> entTypeToConvert)
        {
            DbTableWithSeedInfo tbl = new DbTableWithSeedInfo(entTypeToConvert.Key.ToDbTableInfo());
            tbl.SeedDataProviders = entTypeToConvert.Value;
            return tbl;
        }

        internal EntityBuilder()
        {
            _dicTyps = new Dictionary<Type, List<IDataProcessor>>();
        }

        internal DbTableWithSeedInfo[] TableSpecs => this._dicTyps.Select(typ => convertTableInfo(typ)).ToArray();

        public virtual void Entity<TEntity>() where TEntity : class
        {
            Entity<TEntity>(null);
        }
        public virtual void Entity<TEntity>(IEntitySeedDataProvider<TEntity> seedDataProvider) where TEntity : class
        {
            addEntityTyp(typeof(TEntity), seedDataProvider);
        }
        private void addEntityTyp(Type typToAdd, IDataProcessor seedDataProvider = null)
        {
            List<IDataProcessor> existEntTyp = null;
            _dicTyps.TryGetValue(typToAdd, out existEntTyp);
            if (existEntTyp != null)
            {
                if (seedDataProvider != null)
                    existEntTyp.Add(seedDataProvider);
            }
            else
            {
                var sps = seedDataProvider == null ?
                    new List<IDataProcessor>() : new List<IDataProcessor>() { seedDataProvider };
                _dicTyps.Add(typToAdd, sps);
            }
        }
    }
}

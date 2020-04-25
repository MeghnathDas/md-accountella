/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using Amazon.DynamoDBv2.DataModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public class EntityBuilder: IEntityBuilder
    {
        private Dictionary<Type, List<IExecuter>> _dicTyps;
        private TableInfo convertTableInfo(KeyValuePair<Type, List<IExecuter>> entTypeToConvert)
        {
            var tbl = new TableInfo();
            tbl.SeedDataProviders = entTypeToConvert.Value;
            var tblAttr = entTypeToConvert.Key.GetCustomAttribute<DynamoDBTableAttribute>();
            tbl.tableName = tblAttr != null ? tblAttr.TableName : entTypeToConvert.Key.Name;
            tbl.attributes = entTypeToConvert.Key.GetProperties().Select(tf =>
            {
                var attr = new TableInfo.attrINfo
                {
                    name = tf.Name,
                    dataType = tf.GetType(),
                    isPrimary = tf.GetCustomAttributes(typeof(DynamoDBHashKeyAttribute), true).Length > 0
                };
                return attr;
            }).ToList();
            return tbl;
        }

        internal EntityBuilder()
        {
            _dicTyps = new Dictionary<Type, List<IExecuter>>();
            addEntityTyp(typeof(DbMigration));
        }

        internal TableInfo[] TableSpecs => this._dicTyps.Select(typ => convertTableInfo(typ)).ToArray();

        public virtual void Entity<TEntity>() where TEntity : class
        {
            Entity<TEntity>(null);
        }
        public virtual void Entity<TEntity>(IEntitySeedDataProvider<TEntity> seedDataProvider) where TEntity : class
        {
            addEntityTyp(typeof(TEntity), seedDataProvider);
        }
        
        public void IncludeAllAvailableEntities()
        {
            var callerAsmTyps = getTableTyps(new Assembly[] { Assembly.GetCallingAssembly() });
            var callerRefAsmsTyps = getTableTyps(Assembly.GetCallingAssembly().GetReferencedAssemblies());

            callerAsmTyps.ToList().ForEach(x => addEntityTyp(x));
            callerRefAsmsTyps.ToList().ForEach(x => addEntityTyp(x));
        }
        private void addEntityTyp(Type typToAdd, IExecuter seedDataProvider = null)
        {
            List<IExecuter> existEntTyp = null;
            _dicTyps.TryGetValue(typToAdd, out existEntTyp);
            if (existEntTyp != null)
            {
                if (seedDataProvider != null)
                    existEntTyp.Add(seedDataProvider);
            }
            else
            {
                var sps = seedDataProvider == null ?
                    new List<IExecuter>() : new List<IExecuter>() { seedDataProvider };
                _dicTyps.Add(typToAdd, sps);
            }
        }
        private IEnumerable<Type> getTableTyps(IEnumerable<AssemblyName> assemblyNames)
        {
            var asms = assemblyNames.Select(asNme => Assembly.Load(asNme));
            return getTableTyps(asms);
        }
        private IEnumerable<Type> getTableTyps(IEnumerable<Assembly> assemblies)
        {
            var tblTyps = from a in assemblies
                          from t in a.GetTypes()
                          let attributes = t.GetCustomAttributes(typeof(DynamoDBTableAttribute), true)
                          where attributes != null && attributes.Length > 0
                          select t;
            return tblTyps;
        }
    }
}

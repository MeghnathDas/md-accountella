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
    public class ModelBuilder: IModelBuilder
    {
        private List<Type> _lstTyps;
        private TableInfo convertTableInfo(Type typ)
        {
            var tbl = new TableInfo();
            tbl.tableName = typ.GetCustomAttribute<DynamoDBTableAttribute>().TableName;
            tbl.attributes = typ.GetProperties().Select(tf =>
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
        
        TableInfo[] IModelBuilder.Tables => this._lstTyps.Select(typ => convertTableInfo(typ)).ToArray();

        public virtual void Entity<TEntity>() where TEntity : class
        {
            addEntityTyps(new Type[] { typeof(TEntity) });
        }
        public void IncludeAllAvailableEntities()
        {
            var callerAsmTyps = getTableTyps(new Assembly[] { Assembly.GetCallingAssembly() });
            var callerRefAsmsTyps = getTableTyps(Assembly.GetCallingAssembly().GetReferencedAssemblies());
            
            addEntityTyps(callerAsmTyps);
            addEntityTyps(callerRefAsmsTyps);
        }
        private void addEntityTyps(IEnumerable<Type> typsToAdd)
        {
            if (_lstTyps == null)
                _lstTyps = new List<Type>();
            _lstTyps.AddRange(typsToAdd);
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

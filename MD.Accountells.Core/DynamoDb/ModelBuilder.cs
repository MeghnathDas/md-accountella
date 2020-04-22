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
    public class ModelBuilder
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

        internal TableInfo[] Tables => this._lstTyps.Select(typ => convertTableInfo(typ)).ToArray();

        public virtual void Entity<TEntity>() where TEntity : class
        {
            if (_lstTyps == null)
                _lstTyps = new List<Type>();

            _lstTyps.Add(typeof(TEntity));
        }
    }
}

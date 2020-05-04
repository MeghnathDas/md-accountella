/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    internal static class Helper
    {
        public static DbTableInfo ToDbTableInfo(this Type type)
        {
            DbTableInfo tbl = new DbTableInfo();
            tbl.tableName = type.Name;
            tbl.attributes = type.GetProperties().Select(tf =>
            {
                var attr = new DbTableAttributeInfo
                {
                    name = tf.Name,
                    dataType = tf.PropertyType,
                    isPrimary = tf.GetCustomAttributes(typeof(BsonIdAttribute), true).Length > 0
                };
                return attr;
            }).ToList();
            return tbl;
        }
    }
}

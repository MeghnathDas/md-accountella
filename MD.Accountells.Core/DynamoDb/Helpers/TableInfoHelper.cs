/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb.Helpers
{
    using Amazon.DynamoDBv2.DataModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    internal static class TableInfoHelper
    {
        public static DbTableInfo ToDbTableInfo(this Type type)
        {
            DbTableInfo tbl = new DbTableInfo();
            var tblAttr = type.GetCustomAttribute<DynamoDBTableAttribute>();
            tbl.tableName = tblAttr != null ? tblAttr.TableName : type.Name;
            tbl.attributes = type.GetProperties().Select(tf =>
            {
                var attr = new DbTableAttributeInfo
                {
                    name = tf.Name,
                    dataType = tf.PropertyType,
                    isPrimary = tf.GetCustomAttributes(typeof(DynamoDBHashKeyAttribute), true).Length > 0,
                    isRange = tf.GetCustomAttributes(typeof(DynamoDBRangeKeyAttribute), true).Length > 0
                };
                return attr;
            }).ToList();
            return tbl;
        }

        public static string GetTableName(this Type type)
        {
            var tblAttr = type.GetCustomAttribute<DynamoDBTableAttribute>();
            return tblAttr != null ? tblAttr.TableName : type.Name;
        }
    }
}

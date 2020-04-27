using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MD.Accountella.DL.Helper
{
    internal static class DbUtility
    {
        public static string FormatSeedDataId(string id)
        {
            return $"{id}_system";
        }
        public static string GetTableName<TEntity>() where TEntity: class
        { 
            return GetTableName(typeof(TEntity));
        }
        public static string GetTableName(Type type)
        {
            var tblAttr = type.GetCustomAttribute<DynamoDBTableAttribute>();
            return tblAttr != null ? tblAttr.TableName : type.Name;
        }
    }
}

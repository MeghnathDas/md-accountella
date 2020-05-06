/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    internal static class BulkWriteExtension
    {
        public static Task<BulkWriteResult<T>> BulkUpsert<T>(this IMongoCollection<T> collection, IEnumerable<T> records)
        {
            string keyname = string.Empty;

            #region Get Primary Key Name 
                keyname = getPropNameByCustomAttribute<T, BsonIdAttribute>();
                keyname = string.IsNullOrWhiteSpace(keyname) ? "_id" : keyname;
            #endregion

            return collection.BulkWriteAsync(
                    records.Select(rec =>
                    {
                        var filter = Builders<T>.Filter.Eq(keyname, rec.GetType().GetProperty(keyname).GetValue(rec, null));
                        return new ReplaceOneModel<T>(filter, rec) { IsUpsert = true };
                    })
                );
        }
        private static string getPropNameByCustomAttribute<T, TAttr>() where TAttr: Attribute
        {
            var keyProp = typeof(T).GetProperties()
                                       .Where(prop => prop.GetCustomAttributes(typeof(TAttr), true).Any());

            return keyProp.Any() ? keyProp.First().Name : null;
        }
    }
}

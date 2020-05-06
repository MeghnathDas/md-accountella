
/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb.Extensions
{
    using MongoDB.Bson.Serialization;
    using System;
    public class CustomIdGeneratorWithGuidAndTableName<TEntity> : IIdGenerator where TEntity : class
    {

        public object GenerateId(object container, object document)
        {
            return typeof(TEntity).Name + "_" + Guid.NewGuid().ToString();
        }

        public bool IsEmpty(object id)
        {
            return id == null || String.IsNullOrEmpty(id.ToString());
        }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using MD.Accountella.Core.MongoDb.Extensions;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System;

    public class EntityCategory
    {
        [BsonId(IdGenerator = typeof(CustomIdGeneratorWithGuidAndTableName<EntityCategory>))]
        public string Id { get; set; }

        public string Name { get; set; }
        public string _parentId { get; set; }
        public int SequenceNo { get; set; }
        public AppModuleEnum ForModule { get; set; }
        public bool IsReadOnly { get; set; }

        [BsonIgnore]
        public virtual EntityCategory[] SubCategories { get; set; }
    }
}

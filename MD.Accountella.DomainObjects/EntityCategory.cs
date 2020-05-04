/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class EntityCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SysId { get; set; }
        public string Name { get; set; }
        public string _parentId { get; set; }
        public int SequenceNo { get; set; }

        [BsonIgnore]
        public virtual EntityCategory[] SubCategories { get; set; }
        public AppModuleEnum ForModule { get; set; }
        public bool IsReadOnly { get; set; }
    }
}

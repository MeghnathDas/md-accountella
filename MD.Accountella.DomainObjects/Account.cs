/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single Account
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SysId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string _CategoryId { get; set; }

        [BsonIgnore]
        public virtual EntityCategory Category { get; set; }
        public bool IsActive { get; set; }
        public bool IsReadOnly { get; set; }
    }
}


﻿/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single Account
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using MD.Accountella.Core.MongoDb.Extensions;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System;

    public class Account
    {
        [BsonId(IdGenerator = typeof(CustomIdGeneratorWithGuidAndTableName<Account>))]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string _CategoryId { get; set; }

        [BsonIgnore]
        public virtual EntityCategory Category { get; set; }
        public bool IsActive { get; set; }
        public bool IsReadOnly { get; set; }
    }
}


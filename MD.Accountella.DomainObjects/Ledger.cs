/// <summary>
/// Author: Meghnath Das
/// Description: Model represents a Ledger entry
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    using MD.Accountella.Core.MongoDb;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    public class Ledger
    {
        [BsonId(IdGenerator = typeof(CustomIdGeneratorWithGuidAndTableName<EntityCategory>))]
        public string LedgerEntryId { get; set; }
        public string _AccTxnId { get; set; }

        [BsonRequired]
        public int Seq { get; set; }

        [BsonRequired]
        public string _AccountId { get; set; }

        [BsonRequired]
        public double Amount { get; set; }
        public int? VersionNumber { get; set; }
    }
}

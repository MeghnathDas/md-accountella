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

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? CreatedOn { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? LastModifiedOn { get; set; }

        [BsonRequired]
        public string _AccountId { get; set; }
        public string SourceCurrencyName { get; set; }
        public string SourceCurrencyRate { get; set; }
        public string CurrentCurrencyName { get; set; }

        [BsonRequired]
        public double TxnAmt { get; set; }
        public string Narration { get; set; }

        [BsonRequired]
        public string _refId { get; set; }

        [BsonRequired]
        public string RefType { get; set; }
        public int? VersionNumber { get; set; }
    }
}

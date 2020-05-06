/// <summary>
/// Author: Meghnath Das
/// Description: Model represents a Ledger entry
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    using MD.Accountella.Core.MongoDb.Extensions;
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
        public string _AccountId { get; set; }
        public string SourceCurrencyName { get; set; }
        public string SourceCurrencyRate { get; set; }
        public string CurrentCurrencyName { get; set; }
        public double TxnAmt { get; set; }
        public string Narration { get; set; }
        public string _refId { get; set; }
        public string RefType { get; set; }
        public int? VersionNumber { get; set; }
    }
}

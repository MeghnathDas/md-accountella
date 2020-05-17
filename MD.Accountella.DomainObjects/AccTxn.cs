/// <summary>
/// Author: Meghnath Das
/// Description: Model represents an Account Transaction
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    using MD.Accountella.Core.MongoDb;
    using MongoDB.Bson.Serialization.Attributes;
    
    public enum AccTxnType { income, expence, journal, contra }
    public enum AccTxnRefType { sale, purchase }
    public class AccTxn
    {
        [BsonId(IdGenerator = typeof(CustomIdGeneratorWithGuidAndTableName<EntityCategory>))]
        public string AccTxnId { get; set; }
        public AccTxnType AccTxnType { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? CreatedOn { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? LastModifiedOn { get; set; }
        public string Narration { get; set; }
        public string Note { get; set; }
        public string SourceCurrencyName { get; set; }
        public string SourceCurrencyRate { get; set; }
        public string TransactionCurrencyName { get; set; }

        [BsonRequired]
        public double TxnAmt { get; set; }
        
        [BsonIgnore]
        public virtual Ledger[] LedgerEntries { get; set; }

        public string _refId { get; set; }
        public AccTxnRefType RefType { get; set; }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description: Model represents a Ledger entry
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable(Helpers.Utils.tableNamePrefix + "Ledger")]
    public class Ledger
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBRangeKey]
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string _AccountId { get; set; }
        public string SourceCurrencyName { get; set; }
        public string SourceCurrencyRate { get; set; }
        public string CurrentCurrencyName { get; set; }
        public double TxnAmt { get; set; }
        public string Narration { get; set; }
        public string _refId { get; set; }
        public string RefType { get; set; }
        public int _CreatedByUserId { get; set; }

        [DynamoDBVersion]
        public int? VersionNumber { get; set; }
    }
}

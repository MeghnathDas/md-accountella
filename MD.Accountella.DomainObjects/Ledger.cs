/// <summary>
/// Author: Meghnath Das
/// Description: Model represents Ledger
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
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string _AccountId { get; set; }
        public string SourceCurrencyName { get; set; }
        public string SourceCurrencyRate { get; set; }
        public string CurrentCurrencyName { get; set; }
        public double TxnAmt { get; set; }
        public string Narration { get; set; }
        public string _refId { get; set; }
        public string RefType { get; set; }
        public int _CreatedByUserId { get; set; }
        public virtual AppUser CreatedByUser { get; set; }
    }
}

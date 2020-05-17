/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single Account Transaction
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DataTransferObjects
{
    using System;

    public class AccTxnDto
    {
        public string AccTxnId { get; set; }
        public string AccTxnType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string Narration { get; set; }
        public string Note { get; set; }
        public string SourceCurrencyName { get; set; }
        public string SourceCurrencyRate { get; set; }
        public string TransactionCurrencyName { get; set; }
        public double TxnAmt { get; set; }
        public string _refId { get; set; }
        public string RefType { get; set; }
        public virtual LedgerDto[] LedgerEntries { get; set; }
    }
}

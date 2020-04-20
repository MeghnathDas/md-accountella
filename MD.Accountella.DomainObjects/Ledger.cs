/// <summary>
/// Author: Meghnath Das
/// Description: Model represents Ledger
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Ledger
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public int _AccountId { get; set; }
        public int _SourceCurrencyId { get; set; }
        public int SourceCurrencyRate { get; set; }
        public int _CurrentCurrencyId { get; set; }
        public double TxnAmt { get; set; }
        public string Narration { get; set; }
        public int _refId { get; set; }
        public string RefType { get; set; }
        public int _CreatedByUserId { get; set; }
        public virtual AppUser CreatedByUser { get; set; }
    }
}

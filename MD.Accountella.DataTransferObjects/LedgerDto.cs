/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single Account Transaction
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DataTransferObjects
{
    public class LedgerDto
    {
        public string LedgerEntryId { get; set; }
        public string _AccTxnId { get; set; }
        public int Seq { get; set; }
        public string _AccountId { get; set; }
        public double Amount { get; set; }
        public int? VersionNumber { get; set; }
        public virtual AccTxnDto AccTransaction { get; set; }
    }
}

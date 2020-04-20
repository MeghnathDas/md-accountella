/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single node of navigation menu
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    public class CurrencyType
    {
        public string Name { get; set; }
        public string SymbolName { get; set; }
        public double Rate { get; set; }
        public bool IsMain { get; set; }
    }
}

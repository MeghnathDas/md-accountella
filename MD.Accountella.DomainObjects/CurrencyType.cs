/// <summary>
/// Author: Meghnath Das
/// Description: 
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable(Helpers.Utils.tableNamePrefix + "CurrencyType")]
    public class CurrencyType
    {
        [DynamoDBHashKey]
        public string Name { get; set; }
        public string SymbolName { get; set; }
        public double Rate { get; set; }
        public bool IsMain { get; set; }
    }
}

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
        public string Id { get; set; }

        [DynamoDBHashKey]
        public string Name { get; set; }
        public string SymbolName { get; set; }
        public double Rate { get; set; }
        public bool IsMain { get; set; }
        public string Symbol { get; set; }
        public bool IsReadOnly { get; set; }
    }
}

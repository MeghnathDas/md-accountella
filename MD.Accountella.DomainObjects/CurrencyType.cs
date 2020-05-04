/// <summary>
/// Author: Meghnath Das
/// Description: 
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class CurrencyType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SysId { get; set; }

        public string Name { get; set; }
        public string SymbolName { get; set; }
        public double Rate { get; set; }
        public bool IsMain { get; set; }
        public string Symbol { get; set; }
        public bool IsReadOnly { get; set; }
    }
}

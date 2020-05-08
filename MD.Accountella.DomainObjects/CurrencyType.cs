/// <summary>
/// Author: Meghnath Das
/// Description: 
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using MD.Accountella.Core.MongoDb;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System;

    public class CurrencyType
    {
        [BsonId(IdGenerator = typeof(CustomIdGeneratorWithGuidAndTableName<CurrencyType>))]
        public string Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }
        public string SymbolName { get; set; }
        public double Rate { get; set; }
        public bool IsMain { get; set; }
        public string Symbol { get; set; }
        public bool IsReadOnly { get; set; }
    }
}

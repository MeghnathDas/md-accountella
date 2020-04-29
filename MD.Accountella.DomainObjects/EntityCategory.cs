/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable(Helpers.Utils.tableNamePrefix + "EntityCategory")]
    public class EntityCategory
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string _parentId { get; set; }
        public int SequenceNo { get; set; }

        [DynamoDBIgnore]
        public virtual EntityCategory[] SubCategories { get; set; }

        [DynamoDBProperty(typeof(EnumTypeConverter<AppModules>))]
        public AppModules ForModule { get; set; }
        public bool IsReadOnly { get; set; }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using Amazon.DynamoDBv2.DataModel;
    public enum AppModule { Account, Item, Vendor, Customer, Purchase, Invoice }

    [DynamoDBTable(Helpers.Utils.tableNamePrefix + "EntityCategory")]
    public class EntityCategory
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string _parentId { get; set; }
        public virtual EntityCategory[] SubCategories { get; set; }
        public AppModule ForModule { get; set; }
        public bool IsReadOnly { get; set; }
    }
}

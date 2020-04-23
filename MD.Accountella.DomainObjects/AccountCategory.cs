/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable(Helpers.Utils.tableNamePrefix + "AccountCategory")]
    public class AccountCategory
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string _parentId { get; set; }
        public virtual AccountCategory[] SubCategories { get; set; }
    }
}

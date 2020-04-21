/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single Account
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    using Amazon.DynamoDBv2.DataModel;
    [DynamoDBTable(Helpers.Utils.tableNamePrefix + "Account")]
    public class Account
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string _CategoryId { get; set; }
        public virtual AccountCategory Category { get; set; }
        public bool IsActive { get; set; }
        public bool IsReadOnly { get; set; }
    }
}


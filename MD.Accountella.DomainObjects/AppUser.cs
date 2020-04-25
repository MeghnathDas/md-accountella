/// <summary>
/// Author: Meghnath Das
/// Description: Model represents application user
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    using Amazon.DynamoDBv2.DataModel;

    [DynamoDBTable(Helpers.Utils.tableNamePrefix + "AppUser")]
    public class AppUser
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBProperty(typeof(DateTimeOffsetTypeConverter))]
        public DateTimeOffset CreatedOn { get; set; }

        [DynamoDBProperty(typeof(DateTimeOffsetTypeConverter))]
        public DateTimeOffset LastModifiedOn { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}

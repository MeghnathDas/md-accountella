/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single Account
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DataTransferObjects
{
    using System;
    public class AccountDto
    {
        public string Id { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string _CategoryId { get; set; }
        public EntityCategoryDto Category { get; set; }
        public bool IsActive { get; set; }
        public bool IsReadOnly { get; set; }
    }
}


/// <summary>
/// Author: Meghnath Das
/// Description: Model represents application user
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using System;
    public class AppUser
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}

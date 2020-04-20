/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single node of navigation menu
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    public class AccountCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int _parentId { get; set; }
        public AccountCategory[] SubCategories { get; set; }
    }
}

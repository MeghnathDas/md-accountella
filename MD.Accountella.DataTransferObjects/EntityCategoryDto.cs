/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DataTransferObjects
{
    public class EntityCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string _parentId { get; set; }
        public EntityCategoryDto[] SubCategories { get; set; }
        public string ForModule { get; set; }
        public bool IsReadOnly { get; set; }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description: Entity Category repository interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using System.Collections.Generic;

    public interface IEntityCategoryRepository
    {
        List<EntityCategory> GetCategories(string id);
        EntityCategory AddCategory(EntityCategory accToAdd);
        void UpdateCategory(string id, EntityCategory accountToUpdate);
        void RemoveCategory(string id);
        ICollection<EntityCategory> GetCategoriesByEntity(AppEntityEnum enitity);
    }
}

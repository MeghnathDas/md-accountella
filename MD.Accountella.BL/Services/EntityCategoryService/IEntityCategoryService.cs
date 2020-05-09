/// <summary>
/// Author: Meghnath Das
/// Description: Account repository interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using MD.Accountella.DataTransferObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IEntityCategoryService
    {
        IEnumerable<EntityCategoryDto> GetCategories(string id);
        EntityCategoryDto AddCategories(EntityCategoryDto catgToAdd);
        void UpdateCategory(string id, EntityCategoryDto catgToUpdate);
        void RemoveCategory(string id);
    }
}

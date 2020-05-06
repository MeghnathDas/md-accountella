/// <summary>
/// Author: Meghnath Das
/// Description: Entity category repository, implementation of IEntityCategoryRepository
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    internal class EntityCategoryRepository: IEntityCategoryRepository
    {
        private readonly AccountellaDbContext _dbContext;
        private readonly IMongoCollection<EntityCategory> _catgColl;
        public EntityCategoryRepository(AccountellaDbContext dbContext)
        {
            this._dbContext = dbContext;
            var vv = new MongoCollectionSettings();
            this._catgColl 
                = this._dbContext.DB.GetCollection<EntityCategory>(nameof(EntityCategory));
        }
        public List<EntityCategory> GetCategories(string id)
        {
            IMongoQueryable<EntityCategory> catgs = _catgColl.AsQueryable();
            if (!string.IsNullOrWhiteSpace(id))
                catgs = catgs.Where(catg => catg.Id.Equals(id));

            return catgs.ToList();
        }
        public EntityCategory AddCategory(EntityCategory catgToAdd)
        {
            if (string.IsNullOrWhiteSpace(catgToAdd.Name))
                throw new Exception("Category name must be provided");
            var catgMatches = _catgColl.Find(catg =>
                        catg.Name.Equals(catgToAdd.Name)
                        && catg._parentId.Equals(catgToAdd._parentId)
                    );

            if (catgMatches.Any())
                throw new Exception("Duplicate category is not allowed");

            if (string.IsNullOrWhiteSpace(catgToAdd._parentId) && catgToAdd.ForModule == AppModuleEnum.Account)
                throw new Exception("Must belong to a parent category");

            if (!string.IsNullOrWhiteSpace(catgToAdd._parentId))
                if (!_catgColl.AsQueryable().Where(catg => catg.Id.Equals(catgToAdd._parentId)).Any())
                    throw new Exception("Invalid parent");

            catgToAdd.IsReadOnly = false;

            try
            {
                _catgColl.InsertOne(catgToAdd);
            }
            catch (Exception)
            {
                return null;
            }
            return catgToAdd;
        }
        public void UpdateCategory(string id, EntityCategory catgToUpdate)
        {
            try
            {
                var catgFound = GetCategories(id);

                if (!catgFound.Any())
                    throw new KeyNotFoundException("Item requested for update not found");
                if (catgFound.First().IsReadOnly)
                    throw new InvalidOperationException("Unable to delete/remove readonly item");

                catgToUpdate.Id = id;
                catgToUpdate.IsReadOnly = catgFound.First().IsReadOnly;
                catgToUpdate._parentId = catgFound.First()._parentId;
                var result = _catgColl.ReplaceOne<EntityCategory>(catg => catg.Id.Equals(catgToUpdate.Id) && catg.IsReadOnly == false, catgToUpdate);

                if (!result.IsModifiedCountAvailable)
                    throw new SystemException("Unable to modify");                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveCategory(string id)
        {
            var catgFound = GetCategories(id);

            if (!catgFound.Any())
                throw new KeyNotFoundException("Category requested for delete not found");

            var result = _catgColl.DeleteOne<EntityCategory>(catg => catg.Id.Equals(id) && catg.IsReadOnly == false);

            if (!result.IsAcknowledged)
                throw new KeyNotFoundException("No matching category found with the provided key");

            if (!(result.DeletedCount > 0))
                throw new Exception("Unknown Error: Category not deleted");
        }
    }
}

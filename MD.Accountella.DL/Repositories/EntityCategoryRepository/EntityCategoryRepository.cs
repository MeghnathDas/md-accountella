/// <summary>
/// Author: Meghnath Das
/// Description: Entity category repository, implementation of IEntityCategoryRepository
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using Amazon.Runtime;
    using MD.Accountella.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    internal class EntityCategoryRepository: IEntityCategoryRepository
    {
        private readonly AccountellaDbContext _dbContext;
        public EntityCategoryRepository(AccountellaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public EntityCategory AddCategory(EntityCategory catgToAdd)
        {
            if (string.IsNullOrWhiteSpace(catgToAdd.Name))
                throw new Exception("Category name must be provided");

            var catgMatches = _dbContext
                .QueryAsync<EntityCategory>("",
                    new DynamoDBOperationConfig
                    {
                        QueryFilter = new List<ScanCondition>
                        {
                            new ScanCondition(nameof(catgToAdd.Name),
                                ScanOperator.Equal,
                                new object [] { catgToAdd.Name }
                            ),
                            new ScanCondition(nameof(catgToAdd._parentId),
                                ScanOperator.Equal,
                                new object [] { catgToAdd._parentId }
                            )
                        },
                        ConditionalOperator = ConditionalOperatorValues.Or
                    }).GetRemainingAsync().Result;
            if (catgMatches.Any())
                throw new Exception("Duplicate category is not allowed");

            if (string.IsNullOrWhiteSpace(catgToAdd._parentId) && catgToAdd.ForModule == AppModules.Account)
                throw new Exception("Must belong to a parent category");

            if (!string.IsNullOrWhiteSpace(catgToAdd._parentId))
            {
                catgMatches = _dbContext
                    .QueryAsync<EntityCategory>(catgToAdd._parentId,
                        new DynamoDBOperationConfig
                        {
                            QueryFilter = new List<ScanCondition>
                            {
                                new ScanCondition(
                                        nameof(catgToAdd.ForModule),
                                        ScanOperator.Equal,
                                        new object [] { catgToAdd.ForModule }
                                    )
                            }
                        }).GetRemainingAsync().Result;                
                if (!catgMatches.Any())
                    throw new Exception("Invalid parent");
            }


            catgToAdd.Id = Guid.NewGuid().ToString();
            catgToAdd.IsReadOnly = false;

            try
            {
                _dbContext.SaveAsync<EntityCategory>(catgToAdd).Wait();
            }
            catch (Exception)
            {
                return null;
            }
            return _dbContext.LoadAsync<EntityCategory>(catgToAdd.Id).Result;
        }
        public List<EntityCategory> GetCategories(string id)
        {
            List<ScanCondition> conditions = new List<ScanCondition>();
            if (!string.IsNullOrWhiteSpace(id))
                conditions.Add(new ScanCondition(nameof(EntityCategory.Id), ScanOperator.Equal, id));
            return _dbContext.ScanAsync<EntityCategory>(conditions).GetRemainingAsync().Result;
        }
        public void UpdateCategory(string id, EntityCategory catgToUpdate)
        {
            try
            {
                var catgFound = GetCategories(id);
                if (!catgFound.Any())
                    throw new KeyNotFoundException("Category requested for update not found");

                catgToUpdate.Id = id;
                catgToUpdate.IsReadOnly = catgFound.First().IsReadOnly;
                catgToUpdate._parentId = catgFound.First()._parentId;
                _dbContext.SaveAsync<EntityCategory>(catgToUpdate);
            }
            catch (AmazonDynamoDBException aDbEx)
            {
                throw new Exception("Data Error: " + aDbEx.Message);
            }
            catch (AmazonServiceException e) { throw new Exception("DB Service Error: " + e.Message); }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveCategory(string id)
        {
            EntityCategory catgToDel = _dbContext.LoadAsync<EntityCategory>(id).Result;
            if (catgToDel == null)
                throw new KeyNotFoundException("No category found with the provided key");
            if (catgToDel.IsReadOnly)
                throw new Exception("Requested item is read only, hence cannot be deleted");
            this._dbContext.DeleteAsync<EntityCategory>(catgToDel).Wait();
        }
    }
}

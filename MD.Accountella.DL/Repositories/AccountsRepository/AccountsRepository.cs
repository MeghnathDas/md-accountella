/// <summary>
/// Author: Meghnath Das
/// Description: Account repository, implementation of IAccountsRepository
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using MD.Accountella.DomainObjects;
    using MD.Accountella.DL.Helper;
    using System.Linq;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System.Data;

    internal class AccountsRepository : IAccountsRepository
    {
        private readonly IMongoCollection<Account> _accColl;
        private readonly IEntityCategoryRepository _categoryRepo;
        public AccountsRepository(AccountellaDbContext dbContext, IEntityCategoryRepository categoryRepo)
        {
            this._categoryRepo = categoryRepo;
            this._accColl
                = dbContext.Db.GetCollection<Account>(nameof(Account));
        }
        public List<Account> GetAccounts(string id)
        {
            IMongoQueryable<Account> accs = _accColl.AsQueryable();
            if (!string.IsNullOrWhiteSpace(id))
                accs = accs.Where(acc => acc.Id.Equals(id));

            return accs.ToList();
        }
        public ICollection<Account> GetAccountsByCategory(string categoryId)
        {
            return _accColl.AsQueryable().Where(acc => acc._CategoryId.Equals(categoryId)).ToList();
        }
        public Account AddAccount(Account accToAdd)
        {
            if (string.IsNullOrWhiteSpace(accToAdd.Name))
                throw new Exception("Name must be provided");
            var catgMatches = _accColl.Find(catg =>
                        catg.Name.Equals(accToAdd.Name)
                    );
            if (catgMatches.Any())
                throw new Exception("Name must be unique");

            if (string.IsNullOrWhiteSpace(accToAdd._CategoryId))
                throw new Exception("Must belong to a category");

            if (!_categoryRepo.GetCategories(accToAdd._CategoryId).Any())
                throw new Exception("Invalid parent category defined");

            accToAdd.IsActive = true;
            accToAdd.IsReadOnly = false;

            try
            {
                _accColl.InsertOne(accToAdd);
            }
            catch (Exception)
            {
                return null;
            }
            return accToAdd;
        }
        public void UpdateAccount(string id, Account accountToUpdate)
        {
            try
            {
                var accFound = GetAccounts(id);

                if (!accFound.Any())
                    throw new KeyNotFoundException("Item requested for update not found");
                if (accFound.First().IsReadOnly)
                    throw new InvalidOperationException("Unable to delete/remove readonly item");

                //Checkig wheather same name is already exists with other or not
                var accMatches = _accColl.Find(acc =>
                            acc.Name.Equals(accountToUpdate.Name)
                            && acc.Id != id
                        );
                if (accMatches.Any())
                    throw new Exception("Requested account name already exists");

                accountToUpdate.Id = id;
                accountToUpdate.IsReadOnly = accFound.First().IsReadOnly;
                if (accFound.First().IsReadOnly)
                    accountToUpdate._CategoryId = accFound.First()._CategoryId;
                var result = _accColl.ReplaceOne<Account>(acc => acc.Id.Equals(accountToUpdate.Id) && acc.IsReadOnly == false, accountToUpdate);

                if (!result.IsModifiedCountAvailable)
                    throw new SystemException("Unable to modify");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveAccount(string id)
        {
            try
            {
                var accFound = GetAccounts(id);

                if (!accFound.Any())
                    throw new KeyNotFoundException("Account requested for delete not found");

                if (accFound.First().IsReadOnly)
                    throw new Exception("Requested item is read only, hence cannot be deleted");

                var result = _accColl.DeleteOne<Account>(acc => acc.Id.Equals(id) && acc.IsReadOnly == false);

                if (!result.IsAcknowledged)
                    throw new KeyNotFoundException("No matching account found with the provided key");

                if (!(result.DeletedCount > 0))
                    throw new Exception("Unknown Error: Account not deleted");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<EntityCategory> GetCategories()
        {
            return _categoryRepo.GetCategoriesByEntity(AppEntityEnum.Account);
        }

        public EntityCategory AddSubCategory(EntityCategory subCategoryToAdd)
        {
            subCategoryToAdd.ForEntity = AppEntityEnum.Account;
            return _categoryRepo.AddCategory(subCategoryToAdd);
        }

        public void RemoveSubCategory(string subCategoryId)
        {
            if (GetAccountsByCategory(subCategoryId).Any())
                throw new ConstraintException("One or more accounts belongs to the requested type, hence cannot be removed");
            _categoryRepo.RemoveCategory(subCategoryId);
        }
    }
}

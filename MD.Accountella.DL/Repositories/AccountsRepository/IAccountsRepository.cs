/// <summary>
/// Author: Meghnath Das
/// Description: Account repository interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountsRepository
    {
        List<Account> GetAccounts(string id);
        Account AddAccount(Account accToAdd);
        void UpdateAccount(string id, Account accountToUpdate);
        void RemoveAccount(string id);
    }
}

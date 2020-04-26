/// <summary>
/// Author: Meghnath Das
/// Description: Account Manager Interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountsRepository
    {
        public Task<List<Account>> GetAccounts(string id);
        public Account AddAccount(Account accToAdd);
        public bool UpdateAccount(Account accToAdd);
        public bool RemoveAccount(string id);
    }
}

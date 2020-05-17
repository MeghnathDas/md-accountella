/// <summary>
/// Author: Meghnath Das
/// Description: Entity Category repository interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using MongoDB.Driver.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountTransactionRepository
    {
        Task<IList<AccTxn>> GetTransactions(string id);
        Task<AccTxn> AddTransaction(AccTxn txnToAdd);
    }
}

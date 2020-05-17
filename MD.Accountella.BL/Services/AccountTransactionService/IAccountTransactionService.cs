/// <summary>
/// Author: Meghnath Das
/// Description: Account Transaction Service Interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using MD.Accountella.DataTransferObjects;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAccountTransactionService
    {
        Task<IList<AccTxnDto>> GetTransactions(string id);
        Task<AccTxnDto> AddTransaction(AccTxnDto transactionToAdd);
    }
}

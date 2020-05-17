/// <summary>
/// Author: Meghnath Das
/// Description: Account Transaction Service Interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using MD.Accountella.DataTransferObjects;
    using MD.Accountella.DL;
    using MD.Accountella.DomainObjects;

    internal class AccountTransactionService : IAccountTransactionService
    {
        private readonly IAccountTransactionRepository _accTranRepo;
        private readonly IMapper _mapper;
        public AccountTransactionService(IAccountTransactionRepository accountTransactionRepository,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._accTranRepo = accountTransactionRepository;
        }

        public async Task<AccTxnDto> AddTransaction(AccTxnDto transactionToAdd)
        {
            var txnToAdd = _mapper.Map<AccTxn>(transactionToAdd);
            var txnAddResult = await _accTranRepo.AddTransaction(txnToAdd);
            return _mapper.Map<AccTxnDto>(txnAddResult);
        }
        public async Task<IList<AccTxnDto>> GetTransactions(string id)
        {
            return _mapper.Map<IList<AccTxnDto>>(await _accTranRepo.GetTransactions(id));
        }
    }
}

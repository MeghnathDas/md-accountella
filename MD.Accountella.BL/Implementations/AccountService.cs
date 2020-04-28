/// <summary>
/// Author: Meghnath Das
/// Description: Delivers navigation menu related services
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using AutoMapper;
    using MD.Accountella.DataTransferObjects;
    using MD.Accountella.DL;
    using MD.Accountella.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountsRepository _accountsRepo;
        public AccountService(IAccountsRepository accountManager, IMapper mapper)
        {
            this._mapper = mapper;
            this._accountsRepo = accountManager;
        }

        public IEnumerable<AccountDto> GetAccounts(string id)
        {
            var accounts = this._accountsRepo.GetAccounts(id);
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }
        public AccountDto AddAccount(AccountDto accountToAdd)
        {
            return _mapper.Map<AccountDto>(
                    this._accountsRepo.AddAccount(_mapper.Map<Account>(accountToAdd))
                );
        }

        public void AlterAccount(string id, AccountDto accountToAlter)
        {
            this._accountsRepo.UpdateAccount(id, _mapper.Map<Account>(accountToAlter));
        }

        public void RemoveAccount(string id)
        {
            this._accountsRepo.RemoveAccount(id);
        }
    }
}

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
            var accounts = this._accountsRepo.GetAccounts(id).Result;
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }
        public AccountDto AddAccount(AccountDto accountToAdd)
        {
            return _mapper.Map<AccountDto>(
                    this._accountsRepo.AddAccount(_mapper.Map<Account>(accountToAdd))
                );
        }

        public bool AlterAccount(int id, AccountDto value)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}

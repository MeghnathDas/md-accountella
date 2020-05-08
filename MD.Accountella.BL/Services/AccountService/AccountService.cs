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
        private readonly IAccountsRepository _repository;
        public AccountService(IAccountsRepository accountsRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = accountsRepository;
        }

        public ICollection<AccountDto> GetAccounts(string id)
        {
            var accounts = this._repository.GetAccounts(id);
            return _mapper.Map<ICollection<AccountDto>>(accounts);
        }
        public AccountDto AddAccount(AccountDto accountToAdd)
        {
            return _mapper.Map<AccountDto>(
                    this._repository.AddAccount(_mapper.Map<Account>(accountToAdd))
                );
        }

        public void UpdateAccount(string id, AccountDto accountToAlter)
        {
            this._repository.UpdateAccount(id, _mapper.Map<Account>(accountToAlter));
        }

        public void RemoveAccount(string id)
        {
            this._repository.RemoveAccount(id);
        }
        public ICollection<EntityCategoryDto> GetCategories()
        {
            return _mapper.Map< ICollection<EntityCategoryDto>>(this._repository.GetCategories());
        }
    }
}

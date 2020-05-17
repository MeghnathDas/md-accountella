/// <summary>
/// Author: Meghnath Das
/// Description: Entity Category repository interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    internal class AccountTransactionRepository : IAccountTransactionRepository
    {
        private readonly IMongoCollection<AccTxn> _accTxnCol;
        private readonly IMongoCollection<Ledger> _ledgerCol;
        private readonly ICurrencyTypeRepository _currencyTypeRepo;
        public AccountTransactionRepository(AccountellaDbContext dbContext, ICurrencyTypeRepository currencyTypeRepo)
        {
            _currencyTypeRepo = currencyTypeRepo;
            this._accTxnCol
                = dbContext.Db.GetCollection<AccTxn>(nameof(AccTxn));
            this._ledgerCol
                = dbContext.Db.GetCollection<Ledger>(nameof(Ledger));
        }
        public async Task<IList<AccTxn>> GetTransactions(string id)
        {
            IMongoQueryable<AccTxn> txns = _accTxnCol.AsQueryable();
            if (!string.IsNullOrWhiteSpace(id))
                txns = txns.Where(txn => txn.AccTxnId.Equals(id));

            return await _accTxnCol.AsQueryable().Where(x => x.AccTxnId.Equals(id)).ToListAsync();
        }
        public async Task<AccTxn> AddTransaction(AccTxn txnToAdd)
        {
            if (txnToAdd.LedgerEntries == null || txnToAdd.LedgerEntries.Length < 2)
                throw new ConstraintException("Incorrect ledger entries provided or no ledger entry found");
            
            if (txnToAdd.LedgerEntries.Length == 2 &&
                txnToAdd.LedgerEntries.Select(x => x._AccountId).Distinct().Count() == 1)
                throw new ConstraintException("Incorrect ledger entries provided or no ledger entry found");

            if (txnToAdd.TxnAmt <= 0)
                throw new DataException("Transaction amount cannot be zero");

            if (string.IsNullOrWhiteSpace(txnToAdd.Narration))
                throw new DataException("Narration/description must be provided");

            txnToAdd.CreatedOn = DateTime.Now;
            txnToAdd.AccTxnId = null;

            using (var session = await _accTxnCol.Database.Client.StartSessionAsync())
            {
                session.StartTransaction();
                try
                {
                    if (string.IsNullOrEmpty(txnToAdd.SourceCurrencyName) ||
                        string.IsNullOrEmpty(txnToAdd.TransactionCurrencyName))
                    {
                        var defCurr = await _currencyTypeRepo.GetMainCurrencyType(session);
                        if (string.IsNullOrEmpty(txnToAdd.TransactionCurrencyName))
                            txnToAdd.TransactionCurrencyName = defCurr.Name;
                    }
                    var ledEntries = txnToAdd.LedgerEntries;
                    // txnToAdd.LedgerEntries = null;
                    await _accTxnCol.InsertOneAsync(session, txnToAdd);
                    ledEntries = ledEntries.Select(led => { led._AccTxnId = txnToAdd.AccTxnId; return led; }).ToArray();
                    await _ledgerCol.InsertManyAsync(session, ledEntries);
                    txnToAdd.LedgerEntries = null;
                    await session.CommitTransactionAsync();
                }
                catch (Exception)
                {
                    await session.AbortTransactionAsync();
                    return null;
                }
            }
            return txnToAdd;
        }
        public async Task<bool> DeleteTransaction(string id)
        {
            DeleteResult deleteResult = null;
            try
            {
                deleteResult = await _accTxnCol.DeleteOneAsync<AccTxn>(txn => txn.AccTxnId.Equals(id));
            }
            catch (Exception)
            {
                return false;
            }
            return deleteResult.DeletedCount > 0;
        }
    }
}

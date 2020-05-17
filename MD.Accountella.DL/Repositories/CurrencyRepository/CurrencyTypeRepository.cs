/// <summary>
/// Author: Meghnath Das
/// Description: Currency type repository
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    internal class CurrencyTypeRepository: ICurrencyTypeRepository
    {
        private readonly IMongoCollection<CurrencyType> _currTypeCol;
        public CurrencyTypeRepository(AccountellaDbContext dbContext)
        {
            this._currTypeCol
                = dbContext.Db.GetCollection<CurrencyType>(nameof(CurrencyType));
        }
        public async Task<IList<CurrencyType>> GetCurrencyTypes(string id)
        {
            IMongoQueryable<CurrencyType> currTyps = _currTypeCol.AsQueryable();
            if (!string.IsNullOrWhiteSpace(id))
                currTyps = currTyps.Where(cTyp => cTyp.Id.Equals(id));

            return await _currTypeCol.AsQueryable().Where(x => x.Id.Equals(id)).ToListAsync();
        }
        public async Task<CurrencyType> GetMainCurrencyType(IClientSessionHandle clientSession = null)
        {
            if (clientSession == null)
            {
                return await _currTypeCol.AsQueryable().FirstOrDefaultAsync(x => x.IsMain);
            } else
            {
                var condition = Builders<CurrencyType>.Filter.Eq(x => x.IsMain, true);
                return await _currTypeCol.Find(clientSession, condition).SingleAsync();
            }
        }
    }
}

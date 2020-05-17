/// <summary>
/// Author: Meghnath Das
/// Description: Currency type repository interface
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICurrencyTypeRepository
    {
        Task<IList<CurrencyType>> GetCurrencyTypes(string id);
        Task<CurrencyType> GetMainCurrencyType(IClientSessionHandle clientSession = null);
    }
}

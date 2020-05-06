/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using System;
    using System.Collections.Generic;
    using MD.Accountella.Core.MongoDb;
    using MD.Accountella.DL.Helper;
    using MD.Accountella.DomainObjects;
    internal class CurrencyTypeSeedDataProvider : EntitySeedDataProvider<CurrencyType>
    {
        public override void SetDataToCreate(List<CurrencyType> data)
        {
            data.Add(new CurrencyType
            {
                Id = "curr_inr_system",
                IsMain = true,
                Name = "INR",
                Symbol = "₹",
                SymbolName = "INR",
                Rate = 1,
                IsReadOnly = true
            });
        }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.Core.MongoDb;
    using MD.Accountella.DL.Helper;
    using MD.Accountella.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    internal class AccountSeedDataProvider : EntitySeedDataProvider<Account>
    {

        public override void SetDataToCreate(List<Account> data)
        {
            data.AddRange(new Account[] {
                    new Account
                    {
                        Id = Helper.DbUtility.FormatSeedDataId("cash_on_hand"),
                        _CategoryId = EntityCategorySeedDataProvider.CashAndBankCategory_SubAsset.Id,
                        Name = "Cash on hand",
                        IsActive = true,
                        IsReadOnly = true
                    },
                    new Account
                    {
                        Id = Helper.DbUtility.FormatSeedDataId("sales"),
                        _CategoryId = EntityCategorySeedDataProvider.IncomeAccountCategory_SubIncome.Id,
                        Name = "Sales",
                        IsActive = true,
                        IsReadOnly = true
                    }
                });
        }
    }
}

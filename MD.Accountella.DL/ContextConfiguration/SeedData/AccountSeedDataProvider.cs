/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.Core.DynamoDb;
    using MD.Accountella.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    internal class AccountSeedDataProvider : EntitySeedDataProvider<Account>
    {
        public override void SetDataToDelete(List<Account> data)
        {
        }

        public override void SetDataToCreateOrUpdate(List<Account> data)
        {
            data.AddRange(new Account[] {
                    new Account
                    {
                        Id = Helper.DbUtility.FormatSeedDataId("cash_on_hand"),
                        _CategoryId = EntityCategorySeedDataProvider.CashAndBankCategory_SubAsset.Id,
                        CreatedOn = DateTime.Now,
                        Name = "Cash on hand",
                        IsActive = true,
                        IsReadOnly = true
                    },
                    new Account
                    {
                        Id = Helper.DbUtility.FormatSeedDataId("sales"),
                        _CategoryId = EntityCategorySeedDataProvider.IncomeAccountCategory_SubIncome.Id,
                        CreatedOn = DateTime.Now,
                        Name = "Sales",
                        IsActive = true,
                        IsReadOnly = true
                    }
                });
        }
    }
}

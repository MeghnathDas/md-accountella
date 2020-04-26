/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using Amazon.DynamoDBv2.DataModel;
    using MD.Accountella.Core.DynamoDb;
    using MD.Accountella.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    internal class EntityCategorySeedDataProvider : EntitySeedDataProvider<EntityCategory>
    {
        #region "Accounts Releted Categories"
        private static EntityCategory getRootAccountCategoryObject(string id, string name, string parentId = null) =>
            new EntityCategory
            {
                Id = Utils.Helper.FormatSeedDataId(id) + "_acc",
                Name = name,
                _parentId = parentId,
                ForModule = ModuleCategory.Account,
                IsReadOnly = true
            };
        public static EntityCategory IncomeAccountCategory => getRootAccountCategoryObject("income", "Income");
        public static EntityCategory ExpenceAccountCategory => getRootAccountCategoryObject("expence", "Expence");
        public static EntityCategory AssetAccountCategory => getRootAccountCategoryObject("asset", "Asset");
        public static EntityCategory CashAndBankCategory_SubAsset => getRootAccountCategoryObject("cash_and_bank_asset", "Credit Card", AssetAccountCategory.Id);
        public static EntityCategory LiabilityAccountCategory => getRootAccountCategoryObject("liability", "Liability");
        public static EntityCategory CreditCardCategory_SubLiability => getRootAccountCategoryObject("credit_card_liability", "Credit Card", LiabilityAccountCategory.Id);

        public static ICollection<EntityCategory> GetAllAccountCategoryObjects() => new EntityCategory[]
        {
            IncomeAccountCategory,
            ExpenceAccountCategory,
            AssetAccountCategory,
            CashAndBankCategory_SubAsset,
            LiabilityAccountCategory,
            CreditCardCategory_SubLiability
        };
        #endregion
        
        public override void SetDataToDelete(List<EntityCategory> data)
        {
        }

        public override void SetDataToCreateOrUpdate(List<EntityCategory> data)
        {
            data.AddRange(GetAllAccountCategoryObjects());
        }
    }
}

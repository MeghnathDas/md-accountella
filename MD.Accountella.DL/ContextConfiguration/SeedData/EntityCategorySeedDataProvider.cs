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
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    internal class EntityCategorySeedDataProvider : EntitySeedDataProvider<EntityCategory>
    {
        private const string categoryIdPrefix = "catg_";
        #region "Accounts Releted Categories"
        private static EntityCategory getRootAccountCategoryObject(string id, string name, int seqNo, string parentId = null) =>
            new EntityCategory
            {
                Id = $"{categoryIdPrefix}{Helper.DbUtility.FormatSeedDataId(id)}_acc",
                Name = name,
                SequenceNo = seqNo,
                _parentId = parentId,
                ForModule = AppModuleEnum.Account,
                IsReadOnly = true
            };
        public static EntityCategory IncomeAndRevenueAccountCategory => getRootAccountCategoryObject("income_root", "Income and Revenue", 1);
        public static EntityCategory IncomeAccountCategory_SubIncome => getRootAccountCategoryObject("income_income", "Income", 11, IncomeAndRevenueAccountCategory.Id);
        public static EntityCategory ExpectedCustomerPaymentCategory_SubLiability => getRootAccountCategoryObject("expected_customer_payment_income", "Expected Customer Payment", 12, LiabilityAccountCategory.Id);
        public static EntityCategory ExpenceAccountCategory => getRootAccountCategoryObject("expence_root", "Expence", 2);
        public static EntityCategory AssetAccountCategory => getRootAccountCategoryObject("asset_root", "Asset", 3);
        public static EntityCategory CashAndBankCategory_SubAsset => getRootAccountCategoryObject("cash_and_bank_asset", "Cash and Bank", 31, AssetAccountCategory.Id);
        public static EntityCategory LiabilityAccountCategory => getRootAccountCategoryObject("liability_root", "Liability", 4);
        public static EntityCategory CreditCardCategory_SubLiability => getRootAccountCategoryObject("credit_card_liability", "Credit Card", 41, LiabilityAccountCategory.Id);
        public static EntityCategory ExpectedVendorPaymentCategory_SubLiability => getRootAccountCategoryObject("expected_vendor_payment_liability", "Expected Vendor Payment", 42, LiabilityAccountCategory.Id);
        public static EntityCategory SalesTaxCategory_SubLiability => getRootAccountCategoryObject("sales_tax_liability", "Sales Tax", 43, LiabilityAccountCategory.Id);
        public static EntityCategory EquityAccountCategory => getRootAccountCategoryObject("equity_root", "Equity", 5);

        public static ICollection<EntityCategory> GetAllAccountCategoryObjects() => new EntityCategory[]
        {
            IncomeAndRevenueAccountCategory,
            IncomeAccountCategory_SubIncome,
            ExpectedCustomerPaymentCategory_SubLiability,
            ExpenceAccountCategory,
            AssetAccountCategory,
            CashAndBankCategory_SubAsset,
            LiabilityAccountCategory,
            CreditCardCategory_SubLiability,
            ExpectedVendorPaymentCategory_SubLiability,
            SalesTaxCategory_SubLiability,
            EquityAccountCategory
        };
        #endregion

        public override void SetDataToCreate(List<EntityCategory> data)
        {
            data.AddRange(GetAllAccountCategoryObjects());
        }
    }
}

/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using MD.Accountella.DomainObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    internal static class AccountSeedData
    {
        private static EntityCategory getAccountMainCategoryObject(string id, string name) => 
            new EntityCategory
            {
                Id = id,
                Name = name,
                _parentId = null,
                ForModule = AppModule.Account,
                IsReadOnly = true
            };
        public static EntityCategory IncomeAccountCategory => getAccountMainCategoryObject("acc-income", "Income");
        public static EntityCategory ExpenceAccountCategory => getAccountMainCategoryObject("acc-expence", "Expence");
        public static EntityCategory AssetAccountCategory => getAccountMainCategoryObject("acc-asset", "Asset");
        public static EntityCategory LiabilityAccountCategory => getAccountMainCategoryObject("acc-liability", "Liability");

        public static ICollection<EntityCategory> GetAllAccountCategoryObjects() => new EntityCategory[]
        {
            IncomeAccountCategory,
            ExpenceAccountCategory,
            AssetAccountCategory,
            LiabilityAccountCategory
        };
    }
}

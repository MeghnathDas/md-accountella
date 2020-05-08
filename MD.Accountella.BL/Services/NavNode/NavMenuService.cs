/// <summary>
/// Author: Meghnath Das
/// Description: Navigation menu related business logics
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using System.Collections.Generic;
    using MD.Accountella.DataTransferObjects;

    public class NavMenuService : INavMenuService
    {
        public ICollection<NavNode> GetPermisibleNavNodes()
        {
            List<NavNode> permissibleNodes = new List<NavNode>();
            permissibleNodes.Add(new NavNode
            {
                id = 1,
                label = "Dashboard",
                icon = "dashboard",
                route = "dashboard"
            });

            //permissibleNodes.Add(getSalesModuleNode());
            //permissibleNodes.Add(getPurchaseModuleNode());
            permissibleNodes.Add(getAccountsModuleNode());
            //permissibleNodes.Add(getReportsModuleNode());

            return permissibleNodes.ToArray();
        }

        private NavNode getSalesModuleNode()
        {
            var node = new NavNode
            {
                id = 2,
                label = "Sales",
                icon = "shopping-cart",
                route = "sale",
                nodes = new NavNode[] {
                    new NavNode {
                      id = 21,
                      label = "Invoices",
                      route = "sales/invoices"
                    },
                    new NavNode {
                      id = 22,
                      label = "Receipt / Income",
                      route = "sales/receipts"
                    },
                    new NavNode {
                      id = 23,
                      label = "Credit Note",
                      route = "sales/cr-notes"
                    },
                    new NavNode {
                      id = 24,
                      label = "Customers",
                      route = "sales/customers"
                    },
                    new NavNode {
                      id = 35,
                      label = "Items",
                      route = "sales/items"
                    }
                }
            };
            return node;
        }
        private NavNode getPurchaseModuleNode()
        {
            var node = new NavNode
            {
                id = 3,
                label = "Purchases",
                icon = "shopping-bag",
                route = "/",
                nodes = new NavNode[] { new NavNode {
                    id = 31,
                    label = "Bills",
                    route = "pruchase/bills"
                },
                    new NavNode {
                        id = 32,
                        label = "Payment / Expence",
                        route = "pruchase/payments"
                    },
                    new NavNode {
                        id = 33,
                        label = "Vendors",
                        route = "pruchase/vendors"
                    }
                }
            };
            return node;
        }
        private NavNode getAccountsModuleNode()
        {
            var node = new NavNode
            {
                id = 4,
                label = "Accounts",
                icon = "calculator",
                route = "accounts",
                nodes = new NavNode[] {                    
                    new NavNode
                    {
                        id = 41,
                        label = "Transactions",
                        route = "accounts/transactions"
                    },
                    new NavNode
                    {
                        id = 42,
                        label = "Ledger",
                        route = "accounts/ledger"
                    },
                    new NavNode
                    {
                        id = 43,
                        label = "Day Book",
                        route = "accounts/day-book"
                    },
                    new NavNode
                    {
                        id = 44,
                        label = "Cash Book",
                        route = "accounts/cash-book"
                    },
                    new NavNode
                    {
                        id = 45,
                        label = "Accounts Map",
                        route = "accounts/map"
                    }
                }
            };
            return node;
        }
        private NavNode getReportsModuleNode()
        {
            var node = new NavNode
            {
                id = 5,
                label = "Reports",
                icon = "bar-chart",
                route = "/",
                nodes = new NavNode[] { new NavNode {
                    id = 51,
                    label = "Profit & Loss",
                    route = "reports/profit-loss"
                },
                    new NavNode {
                        id = 52,
                        label = "Trial Balance",
                        route = "reports/trial-balance"
                    },
                    new NavNode {
                        id = 53,
                        label = "Balance Sheet",
                        route = "reports/balance-sheet"
                    }
                }
            };
            return node;
        }
    }
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-nav-menu',
  templateUrl: './app-side-nav-menu.component.html',
  styleUrls: ['./app-side-nav-menu.component.css']
})
export class SideNavMenuComponent {

  menus = [
    {
      id: 1,
      label: 'Dashboard',
      icon: 'dashboard',
      route: 'dashboard',
      nodes: []
    },
    {
      id: 2,
      label: 'Sales',
      icon: 'shopping-cart',
      route: 'sale',
      nodes: [
        {
          id: 21,
          label: 'Invoices',
          icon: '',
          route: 'sales/invoices',
          nodes: []
        },
        {
          id: 21,
          label: 'Receipt / Income',
          icon: '',
          route: 'sales/receipts',
          nodes: []
        },
        {
          id: 23,
          label: 'Credit Note',
          icon: '',
          route: 'sales/cr-notes',
          nodes: []
        },
        {
          id: 24,
          label: 'Customers',
          icon: '',
          route: 'sales/customers',
          nodes: []
        },
        {
          id: 35,
          label: 'Items',
          icon: '',
          route: 'sales/items',
          nodes: []
        }
      ]
    },
    {
      id: 3,
      label: 'Purchases',
      icon: 'shopping-bag',
      route: '/',
      nodes: [
        {
          id: 31,
          label: 'Bills',
          icon: '',
          route: 'pruchase/bills',
          nodes: []
        },
        {
          id: 32,
          label: 'Payment / Expence',
          icon: '',
          route: 'pruchase/payments',
          nodes: []
        },
        {
          id: 33,
          label: 'Vendors',
          icon: '',
          route: 'pruchase/vendors',
          nodes: []
        }
      ]
    },
    {
      id: 4,
      label: 'Accounts',
      icon: 'calculator',
      route: 'accounts',
      nodes: [
        {
          id: 41,
          label: 'Ledgers',
          icon: '',
          route: 'accounts/ledgers',
          nodes: []
        },
        {
          id: 42,
          label: 'Categories',
          icon: '',
          route: 'accounts/categories',
          nodes: []
        },
        {
          id: 43,
          label: 'Cash Book',
          icon: '',
          route: 'accounts/cash-book',
          nodes: []
        },
        {
          id: 44,
          label: 'Day Book',
          icon: '',
          route: 'accounts/day-book',
          nodes: []
        },
        {
          id: 45,
          label: 'Account Manager',
          icon: '',
          route: 'accounts/manager',
          nodes: []
        }
      ]
    },
    {
      id: 5,
      label: 'Reports',
      icon: 'bar-chart',
      route: '/',
      nodes: [
        {
          id: 51,
          label: 'Profit & Loss',
          icon: '',
          route: 'reports/profit-loss',
          nodes: []
        },
        {
          id: 52,
          label: 'Trial Balance',
          icon: '',
          route: 'reports/trial-balance',
          nodes: []
        },
        {
          id: 53,
          label: 'Balance Sheet',
          icon: '',
          route: 'reports/balance-sheet',
          nodes: []
        }
      ]
    }
  ];

  collapse() {
  }

  toggle() {
  }
}


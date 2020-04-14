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
      id: 3,
      label: 'Sales',
      icon: 'shopping-cart',
      route: 'sale',
      nodes: [
        {
          id: 31,
          label: 'Invoices',
          icon: '',
          route: 'sale/invoices',
          nodes: []
        },
        {
          id: 31,
          label: 'Receipt / Income',
          icon: '',
          route: 'sale/receipts',
          nodes: []
        },
        {
          id: 33,
          label: 'Credit Note',
          icon: '',
          route: 'sale/cr-notes',
          nodes: []
        },
        {
          id: 34,
          label: 'Customers',
          icon: '',
          route: 'sale/customers',
          nodes: []
        },
        {
          id: 35,
          label: 'Items',
          icon: '',
          route: 'sale/items',
          nodes: []
        }
      ]
    },
    {
      id: 4,
      label: 'Purchases',
      icon: 'shopping-bag',
      route: '/',
      nodes: [
        {
          id: 41,
          label: 'Bills',
          icon: '',
          route: 'pruchase/bills',
          nodes: []
        },
        {
          id: 42,
          label: 'Payment / Expence',
          icon: '',
          route: 'pruchase/payments',
          nodes: []
        },
        {
          id: 43,
          label: 'Vendors',
          icon: '',
          route: 'pruchase/vendors',
          nodes: []
        }
      ]
    },
    {
      id: 5,
      label: 'Accounts',
      icon: 'calculator',
      route: 'accounts',
      nodes: [
        {
          id: 51,
          label: 'Ledgers',
          icon: '',
          route: 'accounts/ledgers',
          nodes: []
        },
        {
          id: 52,
          label: 'Categories',
          icon: '',
          route: 'accounts/categories',
          nodes: []
        },
        {
          id: 53,
          label: 'Cash Book',
          icon: '',
          route: 'accounts/cash-book',
          nodes: []
        },
        {
          id: 54,
          label: 'Day Book',
          icon: '',
          route: 'accounts/day-book',
          nodes: []
        },
        {
          id: 55,
          label: 'Account Manager',
          icon: '',
          route: 'accounts/manager',
          nodes: []
        }
      ]
    },
    {
      id: 6,
      label: 'Reports',
      icon: 'bar-chart',
      route: '/',
      nodes: [
        {
          id: 61,
          label: 'Profit & Loss',
          icon: '',
          route: 'reports/profit-loss',
          nodes: []
        },
        {
          id: 62,
          label: 'Trial Balance',
          icon: '',
          route: 'reports/trial-balance',
          nodes: []
        },
        {
          id: 63,
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


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
      icon: 'sad-face',
      route: '/',
      nodes: []
    },
    {
      id: 2,
      label: 'Accounts',
      icon: 'sad-face',
      route: '',
      nodes: [
        {
          id: 21,
          label: 'Ledgers',
          icon: '',
          route: 'accounts/ledgers',
          nodes: []
        },
        {
          id: 22,
          label: 'Categories',
          icon: '',
          route: 'accounts/categories',
          nodes: []
        },
        {
          id: 23,
          label: 'Cash Book',
          icon: '',
          route: 'accounts/cash-book',
          nodes: []
        },
        {
          id: 24,
          label: 'Day Book',
          icon: '',
          route: 'accounts/day-book',
          nodes: []
        },
        {
          id: 25,
          label: 'Account Manager',
          icon: '',
          route: 'accounts/manager',
          nodes: []
        }
      ]
    },
    {
      id: 3,
      label: 'Transaction',
      icon: 'sad-face',
      route: '/',
      nodes: [
        {
          id: 31,
          label: 'Receipt / Income',
          icon: '',
          route: 'transaction/receipt',
          nodes: []
        },
        {
          id: 32,
          label: 'Payment / Expence',
          icon: '',
          route: 'transaction/payment',
          nodes: []
        },
        {
          id: 33,
          label: 'Credit Note',
          icon: '',
          route: 'transaction/cr-note',
          nodes: []
        },
        {
          id: 34,
          label: '',
          icon: '',
          route: 'transaction/dr-note',
          nodes: []
        }
      ]
    },
    {
      id: 4,
      label: 'Reports',
      icon: 'sad-face',
      route: '/',
      nodes: [
        {
          id: 41,
          label: 'Profit & Loss',
          icon: '',
          route: 'reports/profit-loss',
          nodes: []
        },
        {
          id: 42,
          label: 'Trial Balance',
          icon: '',
          route: 'reports/trial-balance',
          nodes: []
        },
        {
          id: 43,
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


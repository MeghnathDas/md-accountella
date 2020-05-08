import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { DayBookComponent } from './day-book/day-book.component';
import { LedgerComponent } from './ledger/ledger.component';
import { CashBookComponent } from './cash-book/cash-book.component';
import { AccountsMapComponent } from './accounts-map/accounts-map.component';
import { TransactionsComponent } from './transactions/transactions.component';

const AccountRoutes: Routes = [
  { path: '', redirectTo: 'transactions' },
  { path: 'transactions', component: TransactionsComponent },
  { path: 'ledger', component: LedgerComponent },
  { path: 'day-book', component: DayBookComponent },
  { path: 'cash-book', component: CashBookComponent },
  { path: 'map', component: AccountsMapComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(AccountRoutes),
  ],
  exports: [RouterModule]
})
export class AccountsRoutingModule { }

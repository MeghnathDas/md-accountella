import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared';
import { AccountsRoutingModule } from './accounts.routing.module';
import { AccountsMapComponent } from './accounts-map/accounts-map.component';
import { DayBookComponent } from './day-book/day-book.component';
import { CashBookComponent } from './cash-book/cash-book.component';
import { LedgerComponent } from './ledger/ledger.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { AccountMapService } from './services/account-map/account-map.service';
import { AccountBooksService as AccountBookService } from './services/account-book/account-book.service';
import { AccountTransactionService } from './services/account-transaction/account-transaction.service';
import { AccountGroupViewerComponent } from './accounts-map/account-group-viewer/account-group-viewer.component';
import { AccountManagerComponent } from './accounts-map/account-manager/account-manager.component';


@NgModule({
  declarations: [
    TransactionsComponent,
    LedgerComponent,
    DayBookComponent,
    CashBookComponent,
    AccountsMapComponent,
    AccountGroupViewerComponent,
    AccountManagerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AccountsRoutingModule
  ],
  providers: [
    AccountMapService,
    AccountBookService,
    AccountTransactionService
  ]
})
export class AccountsModule { }

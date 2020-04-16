import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared';
import { InvoiceManagerComponent } from './invoice-manager/invoice-manager.component';
import { ReceiptManagerComponent } from './receipt-manager/receipt-manager.component';
import { CreditNoteManagerComponent } from './credit-note-manager/credit-note-manager.component';
import { SalesRoutingModule } from './sales.routing.module';
import { CommonMasterComponent } from './sales-common-master/sales-common-master.component';
import { CustomerManagerComponent } from './customer-manager/customer-manager.component';
import { ItemManagerComponent } from './item-manager/item-manager.component';

@NgModule({
  declarations: [
    CommonMasterComponent,
    InvoiceManagerComponent,
    ReceiptManagerComponent,
    CreditNoteManagerComponent,
    CustomerManagerComponent,
    ItemManagerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    SalesRoutingModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SalesModule { }

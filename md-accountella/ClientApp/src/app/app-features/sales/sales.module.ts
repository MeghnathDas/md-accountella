import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared';
import { InvoiceMasterComponent, InvoiceManagerComponent } from './invoices';
import { ReceiptMasterComponent, ReceiptManagerComponent } from './receipt';
import { CreditNoteMasterComponent, CreditNoteManagerComponent } from './credit-note';

const salesRoutes: Routes = [
  { path: '', redirectTo: 'invoices', pathMatch: 'full' },

  { path: 'invoices', component: InvoiceMasterComponent },
  { path: 'invoices/create-new', component: InvoiceManagerComponent },
  { path: 'invoices/:id', component: InvoiceManagerComponent },

  { path: 'receipts', component: ReceiptMasterComponent },
  { path: 'receipts/create-new', component: ReceiptManagerComponent },
  { path: 'receipts/:id', component: ReceiptManagerComponent },

  { path: 'cr-notes', component: CreditNoteMasterComponent },
  { path: 'cr-notes/create-new', component: CreditNoteManagerComponent },
  { path: 'cr-notes/:id', component: CreditNoteManagerComponent },

];

@NgModule({
  declarations: [
    InvoiceMasterComponent, InvoiceManagerComponent,
    ReceiptMasterComponent, ReceiptManagerComponent,
    CreditNoteMasterComponent, CreditNoteManagerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(salesRoutes)
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SalesModule { }

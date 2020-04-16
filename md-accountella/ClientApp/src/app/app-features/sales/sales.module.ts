import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared';
import { SalesComponent } from './sales.component';
import { InvoiceManagerComponent } from './invoice-manager/invoice-manager.component';
import { ReceiptManagerComponent } from './receipt-manager/receipt-manager.component';
import { CreditNoteManagerComponent } from './credit-note-manager/credit-note-manager.component';

const salesRoutes: Routes = [
  { path: '', redirectTo: 'invoices', pathMatch: 'full' },

  { path: 'invoices', component: SalesComponent, data: [{ entityId: 1 }] },
  { path: 'invoices/create-new', component: InvoiceManagerComponent },
  { path: 'invoices/:id', component: InvoiceManagerComponent },

  { path: 'receipts', component: SalesComponent, data: [{ entityId: 2 }] },
  { path: 'receipts/create-new', component: ReceiptManagerComponent },
  { path: 'receipts/:id', component: ReceiptManagerComponent },

  { path: 'cr-notes', component: SalesComponent, data: [{ entityId: 3 }] },
  { path: 'cr-notes/create-new', component: CreditNoteManagerComponent },
  { path: 'cr-notes/:id', component: CreditNoteManagerComponent }
];

@NgModule({
  declarations: [
    SalesComponent,
    InvoiceManagerComponent,
    ReceiptManagerComponent,
    CreditNoteManagerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(salesRoutes)
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SalesModule { }

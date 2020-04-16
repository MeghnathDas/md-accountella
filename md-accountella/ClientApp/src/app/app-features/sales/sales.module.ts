import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared';
import { InvoiceMasterComponent, InvoiceManagerComponent } from './invoices';
import { ReceiptMasterComponent, ReceiptManagerComponent } from './receipt';

const salesRoutes: Routes = [
  { path: '', redirectTo: 'invoices', pathMatch: 'full' },

  { path: 'invoices', component: InvoiceMasterComponent },
  { path: 'invoices/create-new', component: InvoiceManagerComponent },
  { path: 'invoices/:id', component: InvoiceManagerComponent },

  { path: 'receipts', component: ReceiptMasterComponent },
  { path: 'receipts/create-new', component: ReceiptManagerComponent },
  { path: 'receipts/:id', component: ReceiptManagerComponent },

];

@NgModule({
  declarations: [
    InvoiceMasterComponent, InvoiceManagerComponent,
    ReceiptMasterComponent, ReceiptManagerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(salesRoutes)
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SalesModule { }

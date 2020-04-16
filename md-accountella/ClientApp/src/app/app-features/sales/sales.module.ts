import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared';
import { InvoiceMasterComponent, InvoiceManagerComponent } from './invoices';

const salesRoutes: Routes = [
  { path: '', redirectTo: 'invoices', pathMatch: 'full' },
  // {
  //   path: 'invoices',
  //   loadChildren: () => import('./invoices').then(m => m.InvoicesModule)
  // }
  {path: 'invoices', component: InvoiceMasterComponent},
  {path: 'invoices/create-new', component: InvoiceManagerComponent},
  {path: 'invoices/:id', component: InvoiceManagerComponent},
];

@NgModule({
  declarations: [InvoiceMasterComponent, InvoiceManagerComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(salesRoutes)
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SalesModule { }

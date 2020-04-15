import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesComponent } from './sales.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared';
import { InvoicesComponent } from './invoices/invoices.component';

const salesRoutes: Routes = [
  { path: '', redirectTo: 'invoices' },
  {
    path: 'invoices',
    component: InvoicesComponent,
    children: [

    ]
  },

];

@NgModule({
  declarations: [SalesComponent, InvoicesComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(salesRoutes)
  ]
})
export class SalesModule { }

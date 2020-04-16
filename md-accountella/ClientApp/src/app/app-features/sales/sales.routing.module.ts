import { NgModule } from '@angular/core';
import { MasterEntityInfoModel } from '../models';
import { Routes, RouterModule } from '@angular/router';
import { InvoiceManagerComponent } from './invoice-manager/invoice-manager.component';
import { ReceiptManagerComponent } from './receipt-manager/receipt-manager.component';
import { CreditNoteManagerComponent } from './credit-note-manager/credit-note-manager.component';
import { CommonMasterComponent } from './sales-common-master/sales-common-master.component';
import { CustomerManagerComponent } from './customer-manager/customer-manager.component';
import { ItemManagerComponent } from './item-manager/item-manager.component';

const salesRoutes: Routes = [
    { path: '', redirectTo: 'invoices', pathMatch: 'full' },

    {
        path: 'invoices', component: CommonMasterComponent, data: [{
            entity: <MasterEntityInfoModel>{
                caption: 'Invoice',
                visibleColumns: [
                    { key: 'num', value: 'Number' },
                    { key: 'custName', value: 'Customer' },
                    { key: 'amount', value: 'Amount' },
                    { key: 'createdDate', value: 'Invoice Date' },
                    { key: 'dueDate', value: 'Due Date' },
                    { key: 'stat', value: 'Status' }
                ]
            }
        }]
    },
    { path: 'invoices/create-new', component: InvoiceManagerComponent },
    { path: 'invoices/:id', component: InvoiceManagerComponent },

    {
        path: 'receipts', component: CommonMasterComponent, data: [{
            entity: <MasterEntityInfoModel>{
                caption: 'Receipt',
                visibleColumns: [
                    { key: 'num', value: 'Receipt Number' },
                    { key: 'invNum', value: 'Invoice Number' },
                    { key: 'custName', value: 'Customer' },
                    { key: 'amount', value: 'Amount' },
                    { key: 'rcvOn', value: 'Received On' },
                    { key: 'createdOn', value: 'Created On' },
                    { key: 'mode', value: 'Payment Mode' }
                ]
            }
        }]
    },
    { path: 'receipts/create-new', component: ReceiptManagerComponent },
    { path: 'receipts/:id', component: ReceiptManagerComponent },

    {
        path: 'cr-notes', component: CommonMasterComponent, data: [{
            entity: <MasterEntityInfoModel>{
                caption: 'Credit Note',
                visibleColumns: [
                    { key: 'num', value: 'Number' },
                    { key: 'custName', value: 'Customer' },
                    { key: 'amount', value: 'Amount' },
                    { key: 'issuedOn', value: 'Created On' },
                    { key: 'ref', value: 'Reference' }
                ]
            }
        }]
    },
    { path: 'cr-notes/create-new', component: CreditNoteManagerComponent },
    { path: 'cr-notes/:id', component: CreditNoteManagerComponent },

    {
        path: 'customers', component: CommonMasterComponent, data: [{
            entity: <MasterEntityInfoModel>{
                caption: 'Customer',
                visibleColumns: [
                    { key: 'name', value: 'Name' },
                    { key: 'contact', value: 'Contact Info' },
                    { key: 'compAcNo', value: 'Company Account No.' },
                    { key: 'taxAcNo', value: 'Tax Account No.' },
                    { key: 'bAddr', value: 'Billing Address' },
                    { key: 'sAddr', value: 'Shipping Address' },
                    { key: 'createdOn', value: 'Added On' }
                ]
            }
        }]
    },
    { path: 'customers/create-new', component: CustomerManagerComponent },
    { path: 'customers/:id', component: CustomerManagerComponent },

    {
        path: 'items', component: CommonMasterComponent, data: [{
            entity: <MasterEntityInfoModel>{
                caption: 'Sale Item',
                visibleColumns: [
                    { key: 'name', value: 'Name' },
                    { key: 'catg', value: 'Category' },
                    { key: 'salePrice', value: 'Price' },
                    { key: 'createdOn', value: 'Added On' }
                ]
            }
        }]
    },
    { path: 'items/create-new', component: ItemManagerComponent },
    { path: 'items/:id', component: ItemManagerComponent }
];

@NgModule({
    imports: [RouterModule.forChild(salesRoutes)],
    exports: [RouterModule]
})
export class SalesRoutingModule {
}

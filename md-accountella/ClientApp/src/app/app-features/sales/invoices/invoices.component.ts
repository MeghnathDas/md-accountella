import { Component, OnInit } from '@angular/core';
import { TitleService } from '../../shared';
import { KeyValue } from '@angular/common';
import { InvoiceModel } from '../models';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {
  invDataColumns: KeyValue<string, string>[] = [
    { key: 'num', value: 'Number'},
    { key: 'custName', value: 'Customer'},
    { key: 'amount', value: 'Amount'},
    { key: 'createdDate', value: 'Invoice Date'},
    { key: 'dueDate', value: 'Due Date'},
    { key: 'stat', value: 'Status'}
  ];
  invData: InvoiceModel[] = [
    {id: 1, num: 'Inv1', custName: 'Demo Cust 1', amount: 1000, createdDate: '10-04-2020', dueDate: '10-04-2020', stat: 'Paid'},
    {id: 2, num: 'Inv2', custName: 'Demo Cust 2', amount: 1020, createdDate: '12-04-2020', dueDate: '12-04-2020', stat: 'Paid'},
    {id: 3, num: 'Inv3', custName: 'Demo Cust 2', amount: 1030, createdDate: '13-04-2020', dueDate: '13-04-2020', stat: 'Paid'},
    {id: 4, num: 'Inv4', custName: 'Demo Cust 3', amount: 1040, createdDate: '14-04-2020', dueDate: '14-04-2020', stat: 'Paid'},
  ];

  constructor(private titleServ: TitleService) {
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix('Invoices');
  }

}

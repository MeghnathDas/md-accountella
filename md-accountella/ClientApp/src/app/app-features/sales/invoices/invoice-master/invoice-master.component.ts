import { Component, OnInit } from '@angular/core';
import { KeyValue } from '@angular/common';
import { TitleService } from '../../../shared';

@Component({
  selector: 'app-invoice-master',
  templateUrl: './invoice-master.component.html',
  styleUrls: ['./invoice-master.component.css']
})
export class InvoiceMasterComponent implements OnInit {
  caption = 'Invoices';
  invDataColumns: KeyValue<string, string>[] = [
    { key: 'num', value: 'Number'},
    { key: 'custName', value: 'Customer'},
    { key: 'amount', value: 'Amount'},
    { key: 'createdDate', value: 'Invoice Date'},
    { key: 'dueDate', value: 'Due Date'},
    { key: 'stat', value: 'Status'}
  ];

  constructor(private titleServ: TitleService) {
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
  }

}

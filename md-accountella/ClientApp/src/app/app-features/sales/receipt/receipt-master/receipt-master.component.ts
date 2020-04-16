import { Component, OnInit } from '@angular/core';
import { KeyValue } from '@angular/common';
import { TitleService } from '../../../shared';

@Component({
  selector: 'app-receipt-master',
  templateUrl: './receipt-master.component.html',
  styleUrls: ['./receipt-master.component.css']
})
export class ReceiptMasterComponent implements OnInit {
  caption = 'Receipts';
  invDataColumns: KeyValue<string, string>[] = [
    { key: 'num', value: 'Receipt Number'},
    { key: 'invNum', value: 'Invoice Number'},
    { key: 'custName', value: 'Customer'},
    { key: 'amount', value: 'Amount'},
    { key: 'rcvOn', value: 'Received On'},
    { key: 'createdOn', value: 'Created On'},
    { key: 'mode', value: 'Payment Mode'}
  ];

  constructor(private titleServ: TitleService) {
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
  }

}

import { Component, OnInit } from '@angular/core';
import { KeyValue } from '@angular/common';
import { TitleService } from '../../../shared';

@Component({
  selector: 'app-credit-note-master',
  templateUrl: './credit-note-master.component.html',
  styleUrls: ['./credit-note-master.component.css']
})
export class CreditNoteMasterComponent implements OnInit {
  caption = 'Credit Notes';
  invDataColumns: KeyValue<string, string>[] = [
    { key: 'num', value: 'Number'},
    { key: 'custName', value: 'Customer'},
    { key: 'amount', value: 'Amount'},
    { key: 'issuedOn', value: 'Created On'},
    { key: 'ref', value: 'Reference'}
  ];

  constructor(private titleServ: TitleService) {
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
  }

}

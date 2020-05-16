import { Component, OnInit } from '@angular/core';
import { MasterEntityInfoModel } from '../../models';
import { TitleService } from '../../../core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

export enum TxnEntryType {
  income = 'income',
  expence = 'expence',
  journal = 'journal',
  contra = 'contra'
}

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {
  caption = 'Account Transactions';
  accTxnForm: FormGroup;
  entryFormVisible = false;
  entity = <MasterEntityInfoModel>{
    caption: 'Transactions',
    visibleColumns: [
      { key: 'date', value: 'Date' },
      { key: 'desc', value: 'Description' },
      { key: 'tagOrCatg', value: 'Tag/Category' },
      { key: 'amount', value: 'Amount' }
    ]
  };
  data: any[];

  dataSource: any[];
  selected: any;

  get columnSpecs() {
    return this.entity.visibleColumns;
  }

  constructor(private titleServ: TitleService, fb: FormBuilder) {
    this.accTxnForm = fb.group({
      txnDate: [new Date().toLocaleDateString(), Validators.required],
      txnDesc: [''],
      txnAmount: [0],
      crDr: [null, Validators.required],
      acc1: [null, Validators.required],
      acc2: [null, Validators.required],
      vendors: [null],
      customers: [null],
      taxes: [null]
    });
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
  }

  fillData() {
    this.dataSource = this.data;
  }

  // ngAfterViewChecked(): void {
  //   this.fillData();
  // }

  selectionChanged(selected) {
    console.log(selected);
  }

  onKeyPress(event) {
    if (event.keyCode === 13) {
      this.addTrans();
    }
  }
  addTrans() {

  }
  openTxnMaster(entryTyp: TxnEntryType) {
    this.entryFormVisible = true;
  }
}

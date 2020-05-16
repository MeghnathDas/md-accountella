import { Component, OnInit } from '@angular/core';
import { MasterEntityInfoModel } from '../../models';
import { TitleService } from '../../../core';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {
  caption = 'Account Transactions';
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

  constructor(private titleServ: TitleService) { }

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

}

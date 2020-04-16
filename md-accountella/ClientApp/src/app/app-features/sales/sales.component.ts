import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from '../shared';
import { MasterEntityInfoModel } from '../models';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  private entities: MasterEntityInfoModel[] = [
    {
      id: 1,
      caption: 'Invoice',
      visibleColumns: [
        { key: 'num', value: 'Number' },
        { key: 'custName', value: 'Customer' },
        { key: 'amount', value: 'Amount' },
        { key: 'createdDate', value: 'Invoice Date' },
        { key: 'dueDate', value: 'Due Date' },
        { key: 'stat', value: 'Status' }
      ]
    },
    {
      id: 2,
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
    },
    {
      id: 3,
      caption: 'Credit Note',
      visibleColumns: [
        { key: 'num', value: 'Number' },
        { key: 'custName', value: 'Customer' },
        { key: 'amount', value: 'Amount' },
        { key: 'issuedOn', value: 'Created On' },
        { key: 'ref', value: 'Reference' }
      ]
    }
  ];

  currentEntity: MasterEntityInfoModel;
  caption: string;

  constructor(private titleServ: TitleService, private actRoute: ActivatedRoute) {
    const entityId = Number(this.actRoute.snapshot.data[0].entityId);
    this.currentEntity = this.entities.filter(ent => ent.id === entityId)[0];
    this.caption = this.currentEntity.caption + 's';
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
  }


}

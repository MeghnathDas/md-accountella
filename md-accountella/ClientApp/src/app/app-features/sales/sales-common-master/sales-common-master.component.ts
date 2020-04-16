import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MasterEntityInfoModel } from '../../models';
import { TitleService } from 'src/app/core';

@Component({
  selector: 'app-common-master',
  templateUrl: './sales-common-master.component.html',
  styleUrls: ['./sales-common-master.component.css']
})
export class CommonMasterComponent implements OnInit {

  currentEntity: MasterEntityInfoModel;
  caption: string;

  constructor(private titleServ: TitleService, private actRoute: ActivatedRoute) {
    this.currentEntity = this.actRoute.snapshot.data[0].entity;
    this.caption = this.currentEntity.caption + 's';
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
  }
}

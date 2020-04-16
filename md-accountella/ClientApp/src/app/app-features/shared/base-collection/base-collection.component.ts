import { Component, OnInit, Input, Output, EventEmitter, AfterViewChecked } from '@angular/core';
import { KeyValue } from '@angular/common';
import { MasterEntityInfoModel } from '../models/master-entity-info.model';

export class GridDataSource {
  constructor(private data: any[]) {
  }
}
@Component({
  selector: 'app-base-collection',
  templateUrl: './base-collection.component.html',
  styleUrls: ['./base-collection.component.css']
})
export class BaseCollectionComponent implements OnInit, AfterViewChecked {
  @Input() entity: MasterEntityInfoModel;
  @Input() data: any[];
  @Output() selectionchanged: EventEmitter<any> = new EventEmitter<any>();

  dataSource: any[];
  selected: any;

  get columnSpecs() {
    return this.entity.visibleColumns;
  }

  constructor() { }

  ngOnInit(): void {
  }

  fillData() {
    this.dataSource = this.data;
  }

  ngAfterViewChecked(): void {
    this.fillData();
  }

  selectionChanged(selected) {
    this.selectionchanged.emit(selected);
    console.log(selected);
  }

}

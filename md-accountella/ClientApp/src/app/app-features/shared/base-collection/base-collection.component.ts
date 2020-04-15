import { Component, OnInit, Input, Output, EventEmitter, AfterViewChecked } from '@angular/core';
import { KeyValue } from '@angular/common';

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
  selected: any;
  @Input()
  columnSpecs: KeyValue<string, string>[];
  @Input()
  data: any[];
  dataSource: any[];

  @Output() selectionchanged: EventEmitter<any> = new EventEmitter<any>();

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

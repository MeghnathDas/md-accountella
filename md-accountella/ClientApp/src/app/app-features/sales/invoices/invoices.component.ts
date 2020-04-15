import { Component, OnInit } from '@angular/core';
import { TitleService } from '../../shared';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  constructor(private titleServ: TitleService) {
  }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix('Invoices');
  }

}

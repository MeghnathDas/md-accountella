import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from 'src/app/core';

@Component({
  selector: 'app-new-invoice',
  templateUrl: './invoice-manager.component.html',
  styleUrls: ['./invoice-manager.component.css']
})
export class InvoiceManagerComponent implements OnInit {
  invoiceId: number;
  caption = 'Create Invoice';

  constructor(private activatedRoute: ActivatedRoute,
              private titleServ: TitleService) { }

  ngOnInit(): void {
    this.invoiceId = Number(this.activatedRoute.snapshot.params.id);
    if (this.invoiceId) {
      this.caption = 'Invoice';
    }
    this.titleServ.updateTitleWithSuffix(this.caption);
  }
}

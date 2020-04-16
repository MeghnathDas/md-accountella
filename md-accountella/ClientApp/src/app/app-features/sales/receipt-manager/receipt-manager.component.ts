import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from '../../../core';

@Component({
  selector: 'app-receipt-manager',
  templateUrl: './receipt-manager.component.html',
  styleUrls: ['./receipt-manager.component.css']
})
export class ReceiptManagerComponent implements OnInit {
  invoiceId: number;
  caption = 'Create Receipt';

  constructor(private activatedRoute: ActivatedRoute,
              private titleServ: TitleService) { }

  ngOnInit(): void {
    this.invoiceId = Number(this.activatedRoute.snapshot.params.id);
    if (this.invoiceId) {
      this.caption = 'Receipt';
    }
    this.titleServ.updateTitleWithSuffix(this.caption);
  }
}

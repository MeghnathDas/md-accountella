import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from '../../../core';

@Component({
  selector: 'app-customer-manager',
  templateUrl: './customer-manager.component.html',
  styleUrls: ['./customer-manager.component.css']
})
export class CustomerManagerComponent implements OnInit {
  invoiceId: number;
  caption = 'Create Customer';

  constructor(private activatedRoute: ActivatedRoute,
              private titleServ: TitleService) { }

  ngOnInit(): void {
    this.invoiceId = Number(this.activatedRoute.snapshot.params.id);
    if (this.invoiceId) {
      this.caption = 'Customer';
    }
    this.titleServ.updateTitleWithSuffix(this.caption);
  }
}

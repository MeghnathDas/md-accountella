import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from '../../../core';

@Component({
  selector: 'app-item-manager',
  templateUrl: './item-manager.component.html',
  styleUrls: ['./item-manager.component.css']
})
export class ItemManagerComponent implements OnInit {
  invoiceId: number;
  caption = 'Create Sale Item';

  constructor(private activatedRoute: ActivatedRoute,
              private titleServ: TitleService) { }

  ngOnInit(): void {
    this.invoiceId = Number(this.activatedRoute.snapshot.params.id);
    if (this.invoiceId) {
      this.caption = 'Sale Item';
    }
    this.titleServ.updateTitleWithSuffix(this.caption);
  }
}

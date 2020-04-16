import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from '../../../core';

@Component({
  selector: 'app-credit-note-manager',
  templateUrl: './credit-note-manager.component.html',
  styleUrls: ['./credit-note-manager.component.css']
})
export class CreditNoteManagerComponent implements OnInit {
  invoiceId: number;
  caption = 'Create Credit Note';

  constructor(private activatedRoute: ActivatedRoute,
              private titleServ: TitleService) { }

  ngOnInit(): void {
    this.invoiceId = Number(this.activatedRoute.snapshot.params.id);
    if (this.invoiceId) {
      this.caption = 'Credit Note';
    }
    this.titleServ.updateTitleWithSuffix(this.caption);
  }
}

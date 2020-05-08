import { Component, OnInit } from '@angular/core';
import { TitleService } from 'src/app/core';
import { AccountMapService } from '../services/account-map/account-map.service';
import { Category } from '../../models';

@Component({
  selector: 'app-accounts-map',
  templateUrl: './accounts-map.component.html',
  styleUrls: ['./accounts-map.component.css']
})
export class AccountsMapComponent implements OnInit {
  caption = 'Account Mappings';
  accountHeads: Category[];

  constructor(private titleServ: TitleService, private accMapServ: AccountMapService) { }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
    this.loadAccountHeads();
  }
  loadAccountHeads() {
    this.accMapServ.getCategories().subscribe(catgs => {
      this.accountHeads = catgs;
    });
  }
}

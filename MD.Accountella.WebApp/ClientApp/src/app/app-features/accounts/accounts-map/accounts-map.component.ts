import { Component, OnInit, ViewChildren, QueryList, AfterViewChecked } from '@angular/core';
import { TitleService } from 'src/app/core';
import { AccountMapService } from '../services/account-map/account-map.service';
import { Category } from '../../models';
import { ClrTabLink } from '@clr/angular';

@Component({
  selector: 'app-accounts-map',
  templateUrl: './accounts-map.component.html',
  styleUrls: ['./accounts-map.component.css']
})
export class AccountsMapComponent implements OnInit, AfterViewChecked {
  private autoTabSelectionRequired = false;
  private tabIndexToSelect = 0;

  caption = 'Account Mappings';
  accountHeads: Category[];
  @ViewChildren(ClrTabLink) headTabs: QueryList<ClrTabLink>;

  constructor(private titleServ: TitleService, private accMapServ: AccountMapService) { }
  ngAfterViewChecked(): void {
    if (this.headTabs.first && this.autoTabSelectionRequired) {
      this.autoTabSelectionRequired = false;
      this.headTabs.toArray()[this.tabIndexToSelect].activate();
    }
  }
  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
    this.loadAccountHeads(true);
  }
  loadAccountHeads(autoTabSelection: boolean = false, tabIndexToSelect = 0) {
    this.accMapServ.getCategoryMap().subscribe(catgs => {
      this.accountHeads = catgs;
      this.tabIndexToSelect = tabIndexToSelect;
      this.autoTabSelectionRequired = autoTabSelection;
    });
  }
}

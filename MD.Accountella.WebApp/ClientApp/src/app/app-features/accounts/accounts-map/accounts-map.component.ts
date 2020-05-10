import {
  Component, OnInit, ViewChildren, QueryList, AfterViewChecked,
  ViewChild, ElementRef, AfterViewInit, HostListener
} from '@angular/core';
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
  @ViewChild('accTabContainer', { static: true }) accTabContainer: ElementRef;

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.setTabLinks();
  }

  constructor(private titleServ: TitleService, private accMapServ: AccountMapService) { }
  ngAfterViewChecked(): void {
    if (this.headTabs.first && this.autoTabSelectionRequired) {
      this.autoTabSelectionRequired = false;
      this.headTabs.toArray()[this.tabIndexToSelect].activate();
      this.setTabLinks();
    }
  }
  private setTabLinks() {
    if (!this.headTabs || !this.headTabs.first) { return; }
    this.headTabs.forEach(tb => tb.inOverflow = false);
    const pElm = this.headTabs.first.el.nativeElement.parentElement.parentElement;
    pElm.hidden = true;
    const maxPermissibleTabWidth = this.accTabContainer.nativeElement.offsetWidth - 150;
    pElm.hidden = false;

    while (this.headTabs
      .filter(itm => itm.inOverflow === undefined || itm.inOverflow === false)
      .reduce((total, tab) => total + tab.el.nativeElement.offsetWidth, 0) >
      maxPermissibleTabWidth) {
      const avTab =
        this.headTabs.filter(itm => itm.inOverflow === undefined || itm.inOverflow === false).reverse()[0];
      avTab.inOverflow = true;
    }
  }
  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix(this.caption);
    this.loadAccountHeads(true);
  }
  loadAccountHeads(autoTabSelection: boolean = false, tabIndexToSelect = 0) {
    this.tabIndexToSelect = tabIndexToSelect;
    this.accMapServ.getCategoryMap().subscribe(catgs => {
      this.accountHeads = catgs;
      this.autoTabSelectionRequired = autoTabSelection;
    });
  }
  showAddNew(aHead, agroup) {
    const actTabIndex = !aHead ? 0 : this.accountHeads.findIndex(x => x.id === aHead.id);
    this.loadAccountHeads(true, actTabIndex);
  }
}

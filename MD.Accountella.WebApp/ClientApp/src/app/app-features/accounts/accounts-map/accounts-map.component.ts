import {
  Component, OnInit, ViewChildren, QueryList, AfterViewChecked,
  ViewChild, ElementRef, HostListener, AfterViewInit, OnDestroy
} from '@angular/core';
import { TitleService } from 'src/app/core';
import { AccountMapService } from '../services/account-map/account-map.service';
import { Category, Acount } from '../../models';
import { ClrTabLink } from '@clr/angular';
import { AccountManagerComponent } from './account-manager/account-manager.component';
import { AccountGroupViewerComponent } from './account-group-viewer/account-group-viewer.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-accounts-map',
  templateUrl: './accounts-map.component.html',
  styleUrls: ['./accounts-map.component.css']
})
export class AccountsMapComponent implements OnInit, AfterViewChecked, AfterViewInit {
  private accGroupSubscriptions: Subscription[];
  caption = 'Account Mappings';
  accountHeads: Category[];

  @ViewChild(AccountManagerComponent) accManager: AccountManagerComponent;
  @ViewChildren(AccountGroupViewerComponent) accGroupViewers: QueryList<AccountGroupViewerComponent>;

  @ViewChildren(ClrTabLink) headTabs: QueryList<ClrTabLink>;
  @ViewChild('accTabContainer', { static: true }) accTabContainer: ElementRef;
  private autoTabSelectionRequired = false;
  private tabIndexToSelect = 0;

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.setTabLinks();
  }

  constructor(private titleServ: TitleService, private accMapServ: AccountMapService) { }
  ngAfterViewInit(): void {
    this.accManager.submitAction.subscribe((resp: Acount) => {
      if (resp) {
        this.accManager.close();
        const actTabIndex = this.accountHeads.findIndex(x =>
          x.subCategories.filter(xs => xs.id === resp._CategoryId).length > 0);
        this.loadAccountHeads(true, actTabIndex);
      }
    });
  }
  ngAfterViewChecked(): void {
    if (this.headTabs.first && this.autoTabSelectionRequired) {
      this.autoTabSelectionRequired = false;
      this.headTabs.toArray()[this.tabIndexToSelect].activate();
      this.setTabLinks();
    }
    this.setupAccGroupViewerSubscription();
  }
  private setupAccGroupViewerSubscription() {
    this.accGroupSubscriptions?.forEach(sb =>
      sb.unsubscribe()
    );
    this.accGroupSubscriptions = [];
    this.accGroupViewers.forEach(gv => {
      this.accGroupSubscriptions.push(gv.editRequest.subscribe((req: Acount) => {
        this.accManager.open(null, req);
      }));
    });
  }
  private setTabLinks() {
    try {
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
    } catch (err) {
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
}

import {
  Component, OnInit, ViewChildren, QueryList, AfterViewChecked,
  ViewChild, ElementRef, HostListener, AfterViewInit, OnDestroy
} from '@angular/core';
import { TitleService } from 'src/app/core';
import { AccountMapService } from '../services/account-map/account-map.service';
import { Category, Acount } from '../../models';
import { ClrTabLink } from '@clr/angular';
import { AccountManagerComponent } from './account-manager/account-manager.component';
import { Subscription } from 'rxjs';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AccountTypeViewerComponent } from './account-type-viewer/account-type-viewer.component';
import { map, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-accounts-map',
  templateUrl: './accounts-map.component.html',
  styleUrls: ['./accounts-map.component.css']
})
export class AccountsMapComponent implements OnInit, AfterViewChecked, AfterViewInit {
  accTypeForm = new FormGroup({
    name: new FormControl('', Validators.required)
  });
  private accTypeViewerSubscriptions: Subscription[];
  caption = 'Account Mappings';
  accountGroups: Category[];
  selectedAccGroup: Category;

  @ViewChild(AccountManagerComponent) accManager: AccountManagerComponent;
  @ViewChildren(AccountTypeViewerComponent) accGroupViewers: QueryList<AccountTypeViewerComponent>;

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
    this.accManager.addRequest.pipe(
      mergeMap(acc => this.accMapServ.addAccount(acc))
    ).subscribe(resp => {
      this.accManager.close();
      this.loadAccountHeads();
    });
    this.accManager.updateRequest.pipe(
      mergeMap(acc => this.accMapServ.updateAccount(acc))
    ).subscribe(resp => {
      this.accManager.close();
      this.loadAccountHeads();
    });
  }
  ngAfterViewChecked(): void {
    if (this.headTabs.first && this.autoTabSelectionRequired) {
      this.autoTabSelectionRequired = false;
      this.headTabs.toArray()[this.tabIndexToSelect].activate();
      this.setTabLinks();
    }
    this.setupAccTypeViewerSubscriptions();
    this.setSelectedHead();
  }
  private setupAccTypeViewerSubscriptions() {
    this.accTypeViewerSubscriptions?.forEach(sb =>
      sb.unsubscribe()
    );
    this.accTypeViewerSubscriptions = [];
    this.accGroupViewers.forEach(gv => {
      this.accTypeViewerSubscriptions.push(gv.accountMangerOpenRequest.subscribe((req: Acount) => {
        this.accManager.open(this.selectedAccGroup, req);
      }));
      this.accTypeViewerSubscriptions.push(gv.accountTypeDeleteRequest.subscribe((accTyp: Category) => {
        this.accMapServ.removeAccountType(accTyp.id).subscribe(resp =>
          this.loadAccountHeads()
        );
      }));
    });
  }
  private setSelectedHead() {
    try {
      const headId = this.headTabs.filter(tb => tb.active === true)[0].tabLinkId;
      const hd = this.accountGroups.filter(ah => ah.id === headId)[0];
      if (!this.selectedAccGroup || (this.selectedAccGroup.id !== hd.id)) {
        this.selectedAccGroup = hd;
        this.accTypeForm.reset();
      }
    } catch (err) { }
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
    this.loadAccountHeads();
  }
  loadAccountHeads() {
    this.tabIndexToSelect = this.accountGroups?.length > 0 && this.selectedAccGroup ?
      this.accountGroups.findIndex(ah => ah.id === this.selectedAccGroup.id) : 0;
    this.accMapServ.getAccountGroups().subscribe(catgs => {
      this.accountGroups = catgs;
      this.autoTabSelectionRequired = true;
    });
  }
  addAccType() {
    if (this.accTypeForm.dirty && this.accTypeForm.valid) {
      const catgToAdd = <Category>{
        _parentId: this.selectedAccGroup.id,
        name: this.accTypeForm.value.name,
        sequenceNo: this.selectedAccGroup.subCategories ?
          this.selectedAccGroup.subCategories.length + 1 : 1
      };
      this.accMapServ.addAccountType(catgToAdd).subscribe((resp: Category) => {
        this.loadAccountHeads();
        this.accTypeForm.reset();
      });
    } else {
      this.accTypeForm.controls.name.markAsDirty();
      this.accTypeForm.controls.name.setErrors({ 'incorrect': true });
    }
  }
}

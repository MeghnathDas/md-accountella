import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Category, Acount } from '../../../models';
import { AccountMapService } from '../../services/account-map/account-map.service';
import { AccountManagerComponent } from '../account-manager/account-manager.component';

@Component({
  selector: 'app-account-group-viewer',
  templateUrl: './account-group-viewer.component.html',
  styleUrls: ['./account-group-viewer.component.css']
})
export class AccountGroupViewerComponent implements OnInit {
  @Input() accGroup: Category;
  @Output() editRequest: EventEmitter<Account> = new EventEmitter<Account>();

  @Input() accountManager: AccountManagerComponent;
  accounts: Acount[];

  constructor(private accMapServ: AccountMapService) { }

  ngOnInit(): void {
    this.accMapServ.getAccountsBySubCategory(this.accGroup.id).subscribe(accs => {
      this.accounts = accs;
    });
  }
}

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Category, Acount } from '../../../models';
import { AccountMapService } from '../../services/account-map/account-map.service';
import { AccountManagerComponent } from '../account-manager/account-manager.component';

@Component({
  selector: 'app-account-type-viewer',
  templateUrl: './account-type-viewer.component.html',
  styleUrls: ['./account-type-viewer.component.css']
})
export class AccountTypeViewerComponent implements OnInit {
  @Input() accGroup: Category;
  @Output() accountMangerOpenRequest: EventEmitter<Account> = new EventEmitter<Account>();
  @Output() accountTypeDeleteRequest: EventEmitter<Category> = new EventEmitter<Category>();

  @Input() accountManager: AccountManagerComponent;
  accounts: Acount[];

  constructor(private accMapServ: AccountMapService) { }

  ngOnInit(): void {
    this.accMapServ.getAccountsByType(this.accGroup.id).subscribe(accs => {
      this.accounts = accs;
    });
  }
}

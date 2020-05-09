import { Component, OnInit, Input } from '@angular/core';
import { Category, Account } from '../../../models';
import { AccountMapService } from '../../services/account-map/account-map.service';

@Component({
  selector: 'app-account-group-manager',
  templateUrl: './account-group-manager.component.html',
  styleUrls: ['./account-group-manager.component.css']
})
export class AccountGroupManagerComponent implements OnInit {
  @Input() group: Category;
  accounts: Account[];

  constructor(private accMapServ: AccountMapService) { }

  ngOnInit(): void {
    this.accMapServ.getAccountsBySubCategory(this.group.id).subscribe(accs => {
      this.accounts = accs;
    });
  }
}

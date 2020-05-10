import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { AutofocusDirective } from '../../../../core';
import { Acount, Category } from '../../../models';
import { AccountManagerResponse } from './account-manager-response.model';

@Component({
  selector: 'app-account-manager',
  templateUrl: './account-manager.component.html',
  styleUrls: ['./account-manager.component.css']
})
export class AccountManagerComponent implements OnInit {
  @ViewChild(AutofocusDirective) autofocus: AutofocusDirective;
  @Output() submitAction: EventEmitter<AccountManagerResponse> = new EventEmitter<AccountManagerResponse>();

  show = false;

  acc = <Acount> {};

  accHead: Category;

  ngOnInit(): void {
  }

  open(accHead: Category, accGroup: Category, accParam: Acount) {
    this.show = true;
    this.accHead = accHead;
    this.acc = accParam ? Object.create(accParam) : <Acount> {
      name: ''
    };

    setTimeout(() => {
      if (this.autofocus) {
        this.autofocus.setFocus();
      }
    }, 0.1);
  }

  close() {
    this.show = false;
  }

  onKeyPress(event) {
    if (event.keyCode === 13) {
      this.submitAction.emit(<AccountManagerResponse> {
        accountHead: this.accHead,
        isSuccess: true
      });
    }
  }

  onSubmit() {
    this.submitAction.emit(<AccountManagerResponse> {
      accountHead: this.accHead,
      isSuccess: true
    });
  }

}

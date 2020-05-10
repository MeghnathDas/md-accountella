import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef, HostListener } from '@angular/core';
import { AutofocusDirective } from '../../../../core';
import { Acount, Category } from '../../../models';
import { AccountManagerResponse } from './account-manager-response.model';
import { AccountMapService } from '../../services/account-map/account-map.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-account-manager',
  templateUrl: './account-manager.component.html',
  styleUrls: ['./account-manager.component.css']
})
export class AccountManagerComponent implements OnInit {
  accForm: FormGroup;
  @ViewChild(AutofocusDirective) autofocus: AutofocusDirective;
  @Output() submitAction: EventEmitter<AccountManagerResponse> = new EventEmitter<AccountManagerResponse>();
  show = false;
  isAlter = false;

  accGroups: string[] = ['Item1', 'Item2', 'Item3'];
  accHead: Category;

  constructor(private el: ElementRef,
    private accountServ: AccountMapService) {
      this.accForm = new FormGroup({
        category: new FormControl(undefined, Validators.required),
        name: new FormControl('', Validators.required),
        desc: new FormControl('')
      });
  }
  ngOnInit(): void {
  }

  open(accHead: Category, accGroup: Category, accParam: Acount) {
    this.accForm.markAsPristine();
    this.show = true;
    this.accHead = accHead;
    const acc: Acount = accParam ? Object.create(accParam) : undefined;

    this.isAlter = acc !== undefined;

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
      this.submitAction.emit(<AccountManagerResponse>{
        accountHead: this.accHead,
        isSuccess: true
      });
    }
  }

  onSubmit() {
    this.submitAction.emit(<AccountManagerResponse>{
      accountHead: this.accHead,
      isSuccess: true
    });
  }
  @HostListener('submit')
  onFormSubmit() {
    const invalidControl = this.el.nativeElement.querySelector('.ng-invalid');

    if (invalidControl) {
      invalidControl.focus();
    }
  }

}

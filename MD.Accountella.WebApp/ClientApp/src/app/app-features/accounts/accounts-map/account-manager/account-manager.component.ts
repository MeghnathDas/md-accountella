import { Component, ViewChild, Output, EventEmitter, ElementRef } from '@angular/core';
import { AutofocusDirective } from '../../../../core';
import { Acount, Category } from '../../../models';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-account-manager',
  templateUrl: './account-manager.component.html',
  styleUrls: ['./account-manager.component.css']
})
export class AccountManagerComponent {
  accForm: FormGroup;
  @ViewChild(AutofocusDirective) autofocus: AutofocusDirective;
  @Output() addRequest: EventEmitter<Acount> = new EventEmitter<Acount>();
  @Output() updateRequest: EventEmitter<Acount> = new EventEmitter<Acount>();
  show = false;
  isAlter = false;

  currentGroup: Category;
  catgsLoading = false;

  constructor(private el: ElementRef, private fb: FormBuilder) {
    this.accForm = this.fb.group({
      id: [null],
      name: ['', Validators.required],
      desc: [''],
      type: [undefined, Validators.required]
    });
  }

  catgSearchFn(strSearch: string, item: Category) {
    strSearch = strSearch.toLowerCase();
    return item.name.toLowerCase().indexOf(strSearch) > -1;
  }

  open(accGroup: Category, accParam: Acount = null, currTypeId: string = null) {
    this.accForm.reset();
    this.currentGroup = accGroup;
    let currAccTyp: Category;
    if (accParam || currTypeId) {
      currAccTyp = (
        Object.assign({},
          this.currentGroup.subCategories.filter(x =>
            x.id === currTypeId || x.id === accParam?._CategoryId)[0]) as Category);
    }

    if (accParam) {
      this.accForm.patchValue({
        id: accParam.id,
        name: accParam.name,
        desc: accParam.description,
        type: currAccTyp
      });
      this.isAlter = true;
    } else {
      this.accForm.patchValue({
        type: currAccTyp
      });
      this.isAlter = false;
    }

    this.show = true;

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
      this.onSubmit();
    }
  }
  onSubmit() {
    if (this.accForm.dirty && this.accForm.valid) {
      const acc = <Acount>{
        id: this.accForm.value.id,
        name: this.accForm.value.name,
        description: this.accForm.value.desc,
        _CategoryId: this.accForm.value.type.id
      };
      if (acc.id && acc.id?.trim().length > 0) {
        this.updateRequest.emit(acc);
      } else {
        this.addRequest.emit(acc);
      }
    }
  }
}

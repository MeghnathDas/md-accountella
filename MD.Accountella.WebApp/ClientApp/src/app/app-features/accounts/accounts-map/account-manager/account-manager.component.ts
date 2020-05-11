import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef, HostListener } from '@angular/core';
import { AutofocusDirective } from '../../../../core';
import { Acount, Category } from '../../../models';
import { AccountMapService } from '../../services/account-map/account-map.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-account-manager',
  templateUrl: './account-manager.component.html',
  styleUrls: ['./account-manager.component.css']
})
export class AccountManagerComponent implements OnInit {
  accForm = new FormGroup({
    head: new FormControl(''),
    group: new FormControl(undefined, Validators.required),
    name: new FormControl('', Validators.required),
    desc: new FormControl('')
  });
  @ViewChild(AutofocusDirective) autofocus: AutofocusDirective;
  @Output() submitAction: EventEmitter<Acount> = new EventEmitter<Acount>();
  show = false;
  isAlter = false;

  accGroups: Category[];
  catgsLoading = false;

  constructor(private el: ElementRef,
    private accountServ: AccountMapService) {
  }
  ngOnInit(): void {
    this.loadCategories();
  }
  private loadCategories() {
    this.catgsLoading = true;
    this.accountServ.getAccountGroups().subscribe(grps => {
      this.accGroups = grps;
      this.catgsLoading = false;
    });
  }

  catgSearchFn(strSearch: string, item: Category) {
    strSearch = strSearch.toLowerCase();
    return item.name.toLowerCase().indexOf(strSearch) > -1;
  }

  open(accGroup: Category = null, accParam: Acount = null) {
    this.accForm.reset();
    this.show = true;

    if (accParam) {
      const currGrp = this.accGroups.filter(ag => ag.id === accParam._CategoryId)[0];
      this.accForm.patchValue({
        name: accParam.name,
        desc: accParam.description,
        group: currGrp,
        head: currGrp.parent
      });
      this.isAlter = true;
    } else {
      if (accGroup) {
        if (accGroup._ParentId) {
          const currGrp = this.accGroups.filter(ag => ag.id === accGroup.id)[0];
          this.accForm.patchValue({
            group: currGrp,
            head: currGrp.parent
          });
        } else {
          this.accForm.patchValue({
            head: (Object.assign({}, accGroup) as Category)
          });
        }
      }
      this.isAlter = false;
    }

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
    if (this.accForm.valid) {
      const acc = <Acount>{
        name: this.accForm.value.name,
        description: this.accForm.value.desc,
        _CategoryId: this.accForm.value.group.id
      };
      this.submitAction.emit(acc);
    }
  }

  @HostListener('submit')
  onFormSubmit() {
    const invalidControl = this.el.nativeElement.querySelector('.ng-invalid');

    if (invalidControl) {
      invalidControl.focus();
    }
  }
}

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountGroupManagerComponent } from './account-group-manager.component';

describe('AccountGroupManagerComponent', () => {
  let component: AccountGroupManagerComponent;
  let fixture: ComponentFixture<AccountGroupManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountGroupManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountGroupManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

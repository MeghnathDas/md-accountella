import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountsMapComponent } from './accounts-map.component';

describe('AccountsMapComponent', () => {
  let component: AccountsMapComponent;
  let fixture: ComponentFixture<AccountsMapComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountsMapComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountsMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

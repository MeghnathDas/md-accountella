import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountTypeViewerComponent } from './account-type-viewer.component';

describe('AccountTypeViewerComponent', () => {
  let component: AccountTypeViewerComponent;
  let fixture: ComponentFixture<AccountTypeViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountTypeViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountTypeViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

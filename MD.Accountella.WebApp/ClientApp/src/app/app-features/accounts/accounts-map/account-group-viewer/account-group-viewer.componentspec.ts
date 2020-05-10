import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountGroupViewerComponent } from './account-group-viewer.component';

describe('AccountGroupViewerComponent', () => {
  let component: AccountGroupViewerComponent;
  let fixture: ComponentFixture<AccountGroupViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountGroupViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountGroupViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

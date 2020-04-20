import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonMasterComponent as SalesCommonMasterComponent } from './sales-common-master.component';

describe('SalesCommonMasterComponent', () => {
  let component: SalesCommonMasterComponent;
  let fixture: ComponentFixture<SalesCommonMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesCommonMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesCommonMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

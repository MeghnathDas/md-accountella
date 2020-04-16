import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceMasterComponent } from './invoice-master.component';

describe('InvoiceMasterComponent', () => {
  let component: InvoiceMasterComponent;
  let fixture: ComponentFixture<InvoiceMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvoiceMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvoiceMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

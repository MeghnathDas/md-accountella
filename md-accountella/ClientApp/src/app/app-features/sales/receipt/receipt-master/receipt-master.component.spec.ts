import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ReceiptMasterComponent } from './receipt-master.component';


describe('InvoiceMasterComponent', () => {
  let component: ReceiptMasterComponent;
  let fixture: ComponentFixture<ReceiptMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReceiptMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceiptMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

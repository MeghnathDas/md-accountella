import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CreditNoteMasterComponent } from './credit-note-master.component';


describe('CreditNoteMasterComponent', () => {
  let component: CreditNoteMasterComponent;
  let fixture: ComponentFixture<CreditNoteMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreditNoteMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreditNoteMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

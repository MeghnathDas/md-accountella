import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CustomerManagerComponent } from './customer-manager.component';

describe('CustomerManagerComponent', () => {
  let component: CustomerManagerComponent;
  let fixture: ComponentFixture<CustomerManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

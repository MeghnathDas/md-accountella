import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditNoteManagerComponent } from './credit-note-manager.component';

describe('CreditNoteManagerComponent', () => {
  let component: CreditNoteManagerComponent;
  let fixture: ComponentFixture<CreditNoteManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreditNoteManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreditNoteManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

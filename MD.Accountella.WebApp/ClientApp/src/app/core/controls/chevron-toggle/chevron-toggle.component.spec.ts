import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChevronToggleComponent } from './chevron-toggle.component';

describe('ChevronToggleComponent', () => {
  let component: ChevronToggleComponent;
  let fixture: ComponentFixture<ChevronToggleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChevronToggleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChevronToggleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

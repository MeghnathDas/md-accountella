import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BaseCollectionComponent } from './base-collection.component';

describe('BaseCollectionComponent', () => {
  let component: BaseCollectionComponent;
  let fixture: ComponentFixture<BaseCollectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BaseCollectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BaseCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

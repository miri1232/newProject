import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BudgetHomePageComponent } from './budget-home-page.component';

describe('BudgetHomePageComponent', () => {
  let component: BudgetHomePageComponent;
  let fixture: ComponentFixture<BudgetHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BudgetHomePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BudgetHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

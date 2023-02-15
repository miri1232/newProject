import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBankComponent } from './add-bank.component';

describe('AddBankComponent', () => {
  let component: AddBankComponent;
  let fixture: ComponentFixture<AddBankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBankComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

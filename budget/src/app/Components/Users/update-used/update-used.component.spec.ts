import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUsedComponent } from './update-used.component';

describe('UpdateUsedComponent', () => {
  let component: UpdateUsedComponent;
  let fixture: ComponentFixture<UpdateUsedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateUsedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateUsedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

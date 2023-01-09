import { TestBed } from '@angular/core/testing';

import { CategoryIncomeService } from './category-income.service';

describe('CategoryIncomeService', () => {
  let service: CategoryIncomeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryIncomeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

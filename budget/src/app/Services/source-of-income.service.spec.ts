import { TestBed } from '@angular/core/testing';

import { SourceOfIncomeService } from './source-of-income.service';

describe('SourceOfIncomeService', () => {
  let service: SourceOfIncomeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SourceOfIncomeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

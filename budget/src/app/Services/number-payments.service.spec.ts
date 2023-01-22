import { TestBed } from '@angular/core/testing';

import { NumberPaymentsService } from './number-payments.service';

describe('NumberPaymentsService', () => {
  let service: NumberPaymentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NumberPaymentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

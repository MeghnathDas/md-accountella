import { TestBed } from '@angular/core/testing';

import { AccountTransactionService } from './account-transaction.service';

describe('AccountTransactionService', () => {
  let service: AccountTransactionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountTransactionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

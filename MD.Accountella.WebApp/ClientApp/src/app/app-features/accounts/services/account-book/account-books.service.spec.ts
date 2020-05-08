import { TestBed } from '@angular/core/testing';

import { AccountBooksService } from './account-book.service';

describe('AccountBooksService', () => {
  let service: AccountBooksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountBooksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

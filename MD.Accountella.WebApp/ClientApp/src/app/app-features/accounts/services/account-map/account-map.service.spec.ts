import { TestBed } from '@angular/core/testing';

import { AccountMapService } from './account-map.service';

describe('AccountMapService', () => {
  let service: AccountMapService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountMapService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

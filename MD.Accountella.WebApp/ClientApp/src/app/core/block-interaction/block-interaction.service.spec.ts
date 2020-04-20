import { TestBed } from '@angular/core/testing';

import { BlockInteractionService } from './block-interaction.service';

describe('BlockInteractionService', () => {
  let service: BlockInteractionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BlockInteractionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

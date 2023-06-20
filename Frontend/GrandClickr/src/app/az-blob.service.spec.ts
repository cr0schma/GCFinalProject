import { TestBed } from '@angular/core/testing';

import { AzBlobService } from './az-blob.service';

describe('AzBlobService', () => {
  let service: AzBlobService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AzBlobService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

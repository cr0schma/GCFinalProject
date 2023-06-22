import { TestBed } from '@angular/core/testing';

import { GrandClickrDbService } from './grand-clickr-db.service';

describe('GrandClickrDbService', () => {
  let service: GrandClickrDbService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GrandClickrDbService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

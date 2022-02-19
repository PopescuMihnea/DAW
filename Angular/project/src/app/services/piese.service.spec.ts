import { TestBed } from '@angular/core/testing';

import { PieseService } from './piese.service';

describe('PieseService', () => {
  let service: PieseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PieseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

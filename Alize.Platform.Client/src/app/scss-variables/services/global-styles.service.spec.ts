import { TestBed } from '@angular/core/testing';

import { GlobalStylesService } from './global-styles.service';

describe('GlobalStylesService', () => {
  let service: GlobalStylesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GlobalStylesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

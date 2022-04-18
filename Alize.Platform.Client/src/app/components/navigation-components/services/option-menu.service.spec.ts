import { TestBed } from '@angular/core/testing';

import { OptionMenuService } from './option-menu.service';

describe('OptionMenuService', () => {
  let service: OptionMenuService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OptionMenuService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { ColumnBuilderService } from './column-builder.service';

describe('ColumnBuilderService', () => {
  let service: ColumnBuilderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ColumnBuilderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { MatPaginatorIntlCro } from './mat-paginator-intl.service';

describe('MatPaginatorIntlService', () => {
  let service: MatPaginatorIntlCro;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MatPaginatorIntlCro);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

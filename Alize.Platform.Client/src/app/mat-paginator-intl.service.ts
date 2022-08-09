import { Injectable } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class MatPaginatorIntlCro extends MatPaginatorIntl {
  currentLang: string;

  itemsPerPageLabel: string;
  nextPageLabel: string;
  previousPageLabel: string;
  of: string;
  zeroOf: string;

  constructor(private translateService: TranslateService) {
    super();

    const currentLang = localStorage.getItem('lang');
    this.currentLang = (currentLang !== null) ? currentLang : 'en';

    if (this.currentLang === 'es') {
      this.itemsPerPageLabel = this.translateService.instant('ItemsPorPagina');
      this.nextPageLabel = this.translateService.instant('SiguientePagina');
      this.previousPageLabel = this.translateService.instant('PaginaAnterior');
      this.of = ' ' +  this.translateService.instant('de') + ' '; 
      this.zeroOf = this.translateService.instant('0 de');
    } else {
      this.itemsPerPageLabel = this.translateService.instant('ItemsPorPagina');
      this.nextPageLabel = this.translateService.instant('SiguientePagina');
      this.previousPageLabel = this.translateService.instant('PaginaAnterior');
      this.of = ' ' +  this.translateService.instant('de') + ' '; 
      this.zeroOf =  this.translateService.instant('0 de');
    }
  }

  getRangeLabel = (page: number, pageSize: number, length: number) => {
    if (length === 0 || pageSize === 0) {
      return this.zeroOf + length;
    }

    length = Math.max(length, 0);
    const startIndex = page * pageSize;
    // If the start index exceeds the list length, do not try and fix the end index to the end.
    const endIndex = startIndex < length ?
      Math.min(startIndex + pageSize, length) :
      startIndex + pageSize;
    return startIndex + 1 + ' - ' + endIndex + this.of + length;
  };
}

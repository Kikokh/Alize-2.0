import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IColumnDef } from 'src/app/components/models/column.models';
import { TemplatesService } from '../../services/templates.service';

type NewType = MatSort;

@Component({
  selector: 'app-grid-template',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements AfterViewInit, OnInit {
  @Input() columns: IColumnDef[];
  @Input() dataSource: MatTableDataSource<any>;
  @Input() displayedColumns: string[];

  // MatPaginator Inputs
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('sort') sort: MatSort;

  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  pageEvent: PageEvent;

  filterValues = {
    OrdenFabricacion: '',
    CodigoProducto: '',
    Maquina: '',
  };


  constructor(private _templateService: TemplatesService) {
  }
  ngOnInit(): void {
    this._templateService.findControl$.subscribe(optionSelectedList => {
      var ordenFabricacionColumn = optionSelectedList.filter(x => x.type === 'Orden de Fabricacion');
      var ultimaOrdenFabricacion = ordenFabricacionColumn[ordenFabricacionColumn.length - 1];
      var codigoProductoColumn = optionSelectedList.filter(x => x.type === 'Codigo de producto');
      var ultimoCodigoProducto = codigoProductoColumn[codigoProductoColumn.length - 1];
      var maquinaColumn = optionSelectedList.filter(x => x.type === 'Maquina');
      var ultimaMaquina = maquinaColumn[maquinaColumn.length - 1];

      
      if (ultimaOrdenFabricacion) {
        this.filterValues.OrdenFabricacion = ultimaOrdenFabricacion.value;
      }

      if (ultimoCodigoProducto) {
        this.filterValues.CodigoProducto = ultimoCodigoProducto.value;
      }

      if (ultimaMaquina) {
        this.filterValues.Maquina = ultimaMaquina.value;
      }

      if (ultimaOrdenFabricacion || ultimoCodigoProducto || ultimaMaquina) {
        this.dataSource.filter = JSON.stringify(this.filterValues);
      }

      // if ((ultimaOrdenFabricacion !== undefined && (ultimaOrdenFabricacion && ultimaOrdenFabricacion.value === '') 
      //   && ultimoCodigoProducto !== undefined && (ultimoCodigoProducto && ultimoCodigoProducto.value === '')
      //   && ultimaMaquina !== undefined && (ultimaMaquina && ultimaMaquina.value === ''))) {
      //   this.resetFilters();
      // }

    });
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.filterPredicate = this.createFilter();
  }

   // Reset table filters
  //  resetFilters() {
  //   this.dataSource.filter = JSON.stringify({
  //     OrdenFabricacion: '',
  //     CodigoProducto: '',
  //     Maquina: '',
  //   });
  // }

  createFilter(): (data: any, filter: string) => boolean {
    let filterFunction = function(data: any, filter: any): boolean {
      let searchTerms = JSON.parse(filter);
      return data.OrdenFabricacion.indexOf(searchTerms.OrdenFabricacion) !== -1
        && data.CodigoProducto.indexOf(searchTerms.CodigoProducto) !== -1
        && data.Maquina.indexOf(searchTerms.Maquina) !== -1
    }
    return filterFunction;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}

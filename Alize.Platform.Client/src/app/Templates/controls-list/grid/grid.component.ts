import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IColumnDef } from 'src/app/components/models/column.models';

type NewType = MatSort;

@Component({
  selector: 'app-grid-template',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements AfterViewInit {
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


  constructor() {

  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

}

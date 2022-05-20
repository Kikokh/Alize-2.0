import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { IColumnDef, IElementDataApp } from 'src/app/components/models/column.models';
import { ColumnBuilderService } from 'src/app/pages/services/column-builder.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {
  isLoading = true;
  displayedColumns: string[];
  columns: IColumnDef[];
  elementData: IElementDataApp[];
  dataSource: MatTableDataSource<any>;

  constructor(private _columnBuilderService: ColumnBuilderService) { }

  ngOnInit(): void {
    this._columnBuilderService.getApplicationData().subscribe(gridData => {
      this.dataSource = new MatTableDataSource(gridData.data);
      this.columns = gridData.columnDef;
      this.isLoading = false;
      this.displayedColumns = [...this.columns.map(c => c.columnDef)];
    });
  }
}

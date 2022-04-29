import { DataSource } from '@angular/cdk/collections';
import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { RequestApplication } from '../models/application.model';
import { IColumnDef, IElementDataApp, IElementDataCompanies } from '../models/column.models';
import { ApplicationPopUpComponent } from '../pop-up/application-pop-up/application-pop-up.component';

export interface UserData {
  id: string;
  name: string;
  progress: string;
  fruit: string;
}

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit, AfterViewInit {

  @Input() columns: IColumnDef[];
  @Input() elementData: any;
  @Input() table: string;

  title: string;
  subTitle: string;

  dataSource: MatTableDataSource<IElementDataApp>;
  displayedColumns: string[];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  // MatPaginator Inputs
  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // MatPaginator Output
  pageEvent: PageEvent;


  requestApplication = new RequestApplication();
  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';



  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => + str);
    }
  }

  constructor(public dialog: MatDialog, private _snackBar: MatSnackBar) {
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.displayedColumns = this.columns.map(c => c.columnDef);;
    this.dataSource = new MatTableDataSource(this.elementData);

    if (this.table === 'Applications') {
      this.title = 'Administrción'
      this.subTitle = 'Listado de aplicaciones'
    } else if (this.table === 'Companies') {
      this.title = 'Administrción'
      this.subTitle = 'Listado de empresas'
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openDialog() {
    let requestApplication = new RequestApplication();
    requestApplication.mode = 'ADD';

    const dialogRef = this.dialog.open(ApplicationPopUpComponent, {
      data: {
        nombre: '', 
        description: '',
        importantInfo: '',
        mode: requestApplication.mode,
        date: '',
        isActive: ''
      }
    });

    dialogRef.afterClosed().subscribe((result: RequestApplication) => {
      if (result) {
        console.log('The dialog was closed with: ' , result);
        this.requestApplication = result;
        this._snackBar.open('Peticion realizada con exito!','', {
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });
      }
    });
  }


  showDialog(application: IElementDataApp, optionName: string) {
    switch (optionName) {
      case 'Display': {
        this.onDisplay(application);
        break;
      }
      case 'Edit': {
        this.onEdit(application);
        break;
      }
      case 'Group': {
        this.onDisplayGroup(application);
        break;
      }
      case 'Delete': {
        this.onDisplay(application);
        break;
      }
    }
    console.log(optionName);
  }

  onDisplay(application: IElementDataApp) {
    const dialogRef = this.dialog.open(ApplicationPopUpComponent, {
      width: '600px',
      data: {
        nombre: application.Nombre, 
        description: application.Descripcion,
        importantInfo: '',
        mode: 'Display',
        date: new Date(),
        isActive: application.Activo
      },
    });
  }

  onEdit(application: IElementDataApp) {
    const dialogRef = this.dialog.open(ApplicationPopUpComponent, {
      width: '600px',
      data: {
        nombre: application.Nombre, 
        description: application.Descripcion,
        importantInfo: '',
        mode: 'EDIT',
        date: new Date(),
        isActive: application.Activo
      },
    });
  }

  onDisplayGroup(application: IElementDataApp) {
    const dialogRef = this.dialog.open(ApplicationPopUpComponent, {
      width: '600px',
      data: {
        nombre: application.Nombre, 
        description: application.Descripcion,
        importantInfo: '',
        mode: 'GROUP',
        date: new Date(),
        isActive: application.Activo
      },
    });
  }

}

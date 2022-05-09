import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MaterialTheme } from 'src/app/models/theme.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { RequestApplication } from '../models/application.model';
import { IColumnDef, IElementDataApp, IElementDataCompanies } from '../models/column.models';
import { ApplicationPopUpComponent } from '../pop-up/applications/application-pop-up/application-pop-up.component';
import { EntityType, ModePopUpType } from '../pop-up/models/entity-type.enum';
import { OpenPopUpService } from '../pop-up/services/open-pop-up.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit, AfterViewInit {

  @Input() columns: IColumnDef[];
  @Input() elementData: any;
  @Input() entity: EntityType;


  public get Entity(): typeof EntityType {
    return EntityType; 
  }


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

  materialTheme = new MaterialTheme();


  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => + str);
    }
  }

  constructor(
    public dialog: MatDialog,
    private _globalStylesService: GlobalStylesService,
    private _openPopUpService: OpenPopUpService,
    private _snackBar: MatSnackBar) {
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.displayedColumns = this.columns.map(c => c.columnDef);;
    this.dataSource = new MatTableDataSource(this.elementData);
    if (this.entity === EntityType.APPLICATIONS) {
      this.title = 'Administración'
      this.subTitle = 'Listado de Aplicaciones'
    } else if (this.entity === EntityType.COMPANIES) {
      this.title = 'Administracion'
      this.subTitle = 'Listado de Empresas'
    } else if (this.entity === EntityType.USERS) {
      this.title = 'Administracion'
      this.subTitle = 'Listado de Usuarios'
    } else if (this.entity === EntityType.GROUPS) {
      this.title = 'Administracion'
      this.subTitle = 'Listado de Grupos'
    } else if (this.entity === EntityType.MODULES) {
      this.title = 'Administracion'
      this.subTitle = 'Listado de Módulos'
    }

    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isDarkMode = (value === 'dark-theme');
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
    });
  }


  getContentStyles(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-background-grid';
    } else {
      return '';
    }
  }


  getColorHeaderTable(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-header';
    } else {
      return '';
    }
  }

  // getRowStyle(row: number) {
  //   let rowStyle: string;

  //   switch (row) {
  //     case 0 : {
  //       rowStyle = 'id'
  //     }
  //   }

  //   return '';
  // }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openDialog() {
    this._openPopUpService.open(this.entity, ModePopUpType.ADD);
    this._openPopUpService.afterClosed().subscribe(val => {
      this.requestApplication = val;
      // this._snackBar.open('Peticion realizada con exito!', '', {
      //   horizontalPosition: this.horizontalPosition,
      //   verticalPosition: this.verticalPosition,
      // });
    });
  }


  showDialog(data: any, optionName: ModePopUpType) {

    this._openPopUpService.open(this.entity, optionName, data);
    this._openPopUpService.afterClosed().subscribe(val => {
      this.requestApplication = val;
      // this._snackBar.open('Peticion realizada con exito!', '', {
      //   horizontalPosition: this.horizontalPosition,
      //   verticalPosition: this.verticalPosition,
      // });
    });
  }
}

import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { MaterialTheme } from 'src/app/models/theme.model';
import { LoginService } from 'src/app/pages/login/services/login.service';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { IColumnDef, IOperationsModel } from '../../models/column.models';
import { EntityType, ModePopUpType } from '../pop-up/models/entity-type.enum';
import { OpenPopUpService } from '../pop-up/services/open-pop-up.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit, AfterViewInit {

  @Input() columns: IColumnDef[];
  @Input() canInsert: boolean | null = false;
  @Input()
  set elementData(value: any) {
    this.dataSource.data = value;
  }
  @Input() entity: EntityType;
  @Input() actions?: IOperationsModel[];
  // @Input() subTitle: string = '';

  @Output() update = new EventEmitter<any>();
  @Output() updateRole = new EventEmitter<any>();
  @Output() updatePassword = new EventEmitter<any>();
  @Output() add = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  displayedColumns: string[];

  // MatPaginator Output
  pageEvent: PageEvent;

  get ModePopUpType() {
    return ModePopUpType;
  }

  get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(
    public dialog: MatDialog,
    private _openPopUpService: OpenPopUpService,
    private _router: Router,
    public translate: TranslateService,
    private _loginService: LoginService) {

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.displayedColumns = [...this.columns.map(c => c.columnDef), 'operations'];
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  showDialog(optionName: ModePopUpType, data?: any) {
    if (optionName === ModePopUpType.REQUEST) {
      this._router.navigate([`management/queries/${data.id}/assets`]);
    } else if (optionName === ModePopUpType.CHARTS) {
      this._router.navigate([`management/charts/${data.id}/chart`]);
    } else {
      this._openPopUpService.open(this.entity, optionName, data).subscribe(entity => {
        if (entity && entity.action) {
          switch (entity.action) {
            case ModePopUpType.EDIT:
              this.update.emit(entity);
              break;
            case ModePopUpType.ADD:
              this.add.emit(entity);
              break;
            case ModePopUpType.GROUP:
              this.updateRole.emit(entity);
              break;
            case ModePopUpType.PASSWORD:
              this.updatePassword.emit(entity);
              break;
            case ModePopUpType.DELETE:
              this.delete.emit(entity);
              break;
          }
        }
      });
    }
  }

  userActionIsAllowed(action: IOperationsModel): Observable<boolean> {
    return this._loginService.$me.pipe(
      map(user => action.requiredRoles?.includes(user.roleName) ?? true)
    );
  }

}

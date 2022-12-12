import { Component, OnInit } from '@angular/core';
import { switchMap } from 'rxjs/operators';
import { IColumnDef, IOperationsModel } from 'src/app/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { DialogResult } from 'src/app/components/pop-up/users/group-user-pop-up/group-user-pop-up.component';
import { PasswordModel } from 'src/app/components/pop-up/users/password-user-pop-up/models/password.model';
import { User } from 'src/app/models/users.model';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { UsersService } from './users.service';
import { Roles } from 'src/app/constants/roles.constants';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss', '../../layout-main.scss']
})
export class UsersComponent implements OnInit {
  userSelected: User;
  elementData: User[];
  isLoading = true;
  public show:boolean = false;
  displayedColumns: IColumnDef[] = [
    { columnDef: 'Nombre', header: 'Nombre', cell: (element: User) => `${element.firstName + ' ' + element.lastName}` },
    { columnDef: 'Email', header: 'Email', cell: (element: User) => `${element.email}` },
    { columnDef: 'Empresa', header: 'Empresa', cell: (element: User) => `${element.companyName}` },
    { columnDef: 'Grupos', header: 'Grupos', cell: (element: User) => `${element.roleName}` },
    { columnDef: 'Activo', header: 'Activo', cell: (element: User) => `${element.isActive}` }
  ];
  actions: IOperationsModel[] = [
    {
      optionName: ModePopUpType.DISPLAY,
      icon: 'search'
    },
    {
      optionName: ModePopUpType.EDIT,
      icon: 'edit_note',
      getIsAllowed: (userRole: Roles, row: User) => userRole === Roles.AdminPro || userRole === Roles.Distributor || (userRole === Roles.Admin && row.roleName !== Roles.Distributor)
    },
    {
      optionName: ModePopUpType.PASSWORD,
      icon: 'key',
      getIsAllowed: (userRole: Roles, row: User) => userRole === Roles.AdminPro || userRole === Roles.Distributor || (userRole === Roles.Admin && row.roleName !== Roles.Distributor)
    },
    {
      optionName: ModePopUpType.DELETE,
      icon: 'delete_outline',
      getIsAllowed: (userRole: Roles, row: User) => userRole === Roles.AdminPro || userRole === Roles.Distributor || (userRole === Roles.Admin && row.roleName !== Roles.Distributor)
    }
  ]

  get entity(): EntityType {
    return EntityType.USERS;
  }

  constructor(
    private _snackBarService: SnackBarService,
    private _userService: UsersService
  ) { }

  ngOnInit() {
    this._userService.getUsers().subscribe(
      users => {
        this.elementData = users;
        this.isLoading = false;
      });
  }

  toggle() {
    this.show = !this.show;
  }

  updateUsers() {
    this._userService.getUsers().subscribe(
      users => {
        this.elementData = users;
        this.isLoading = false;
      });
  }

  add(user: User) {
    this.isLoading = true;
    this._userService.createNewUser(user).pipe(
      switchMap(() => this._userService.getUsers())
    ).subscribe({
      next: (users) => {
        this.elementData = users;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad creada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });
  }

  update(user: User) {
    this.isLoading = true;
    this._userService.updateUser(user).pipe(
      switchMap(() => this._userService.getUsers())
    ).subscribe({
      next: (users) => {
        this.elementData = users;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad actualizada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });
  }

  updateRole(dialogResult: DialogResult) {
    this.isLoading = true;
    this._userService.updateUserRole(dialogResult.id, dialogResult.roleId).pipe(
      switchMap(() => this._userService.getUsers())
    ).subscribe({
      next: (users) => {
        this.elementData = users;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad actualizada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });
  }

  deleteUser(dialogResult: DialogResult) {
    this.isLoading = true;
    this._userService.deleteUser(dialogResult.id).pipe(
      switchMap(() => this._userService.getUsers())
    ).subscribe(
      (users) => {
        this.elementData = users;
        this._snackBarService.showSnackBar('Entidad eliminada con éxito.');
      },
      (err) => this._snackBarService.showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde'),
      () => this.isLoading = false
    )
  }

  updatePassword(passwordModel: PasswordModel) {
    this.isLoading = true;
    this._userService.changeUserPassword(passwordModel.userId, { newPassword: passwordModel.password, confirmPassword: passwordModel.repeatPassword }).pipe(
      switchMap(() => this._userService.getUsers())
    ).subscribe({
      next: (users) => {
        this.elementData = users;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad actualizada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });
  }


  delete(app: User) { }

}

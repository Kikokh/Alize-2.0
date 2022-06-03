import { Component, OnInit } from '@angular/core';
import { IColumnDef, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { User } from 'src/app/models/users.model';
import { UsersService } from './users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss', '../../layout-main.scss']
})
export class UsersComponent implements OnInit {
  userSelected: User;
  elementData: User[];
  displayedColumns: IColumnDef[] = [
    { columnDef: 'Nombre', header: 'Nombre', cell: (element: User) => `${element.firstName + ' ' + element.lastName}` },
    { columnDef: 'Email', header: 'Email', cell: (element: User) => `${element.email}` },
    { columnDef: 'Empresa', header: 'Empresa', cell: (element: User) => `${element.companyName}` },
    { columnDef: 'Grupos', header: 'Grupos', cell: (element: User) => `${element.roleName}` },
    { columnDef: 'Activo', header: 'Activo', cell: (element: User) => `${element.isActive}` }
  ];
  actions: IOperationsModel[] = [
    // { optionName: ModePopUpType.DISPLAY, icon: 'search' },
    { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
    { optionName: ModePopUpType.GROUP, icon: 'groups' },
    { optionName: ModePopUpType.PASSWORD, icon: 'key' },
    // { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
  ]

  get entity(): EntityType {
    return EntityType.USERS; 
  }
  
  constructor(private _userService: UsersService) {}

  ngOnInit() {
    this._userService.getUsers().subscribe(
      users => this.elementData = users
    );
  }

  updateUsers(){
    this._userService.getUsers().subscribe(
      users => this.elementData = users
    );
  }

}

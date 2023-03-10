import { Component, Inject, OnInit } from '@angular/core';
import { UntypedFormArray, UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Application } from 'src/app/models/application.model';
import { Dialog } from 'src/app/models/dialog.model';
import { User } from 'src/app/models/users.model';
import { ApplicationsService } from 'src/app/pages/administration/applications/applications.service';
import { UsersService } from 'src/app/pages/administration/users/users.service';
@Component({
  selector: 'app-application-group-pop-up',
  templateUrl: './application-group-pop-up.component.html',
  styleUrls: ['./application-group-pop-up.component.scss']
})
export class ApplicationGroupPopUpComponent implements OnInit {

  form: UntypedFormGroup;
  title = '';
  subtitle = '';
  infoText = '';
  userList: User[];

  get users() {
    return this.form?.get('users') as UntypedFormArray;
  }

  constructor(
    private _userService: UsersService,
    private _fb: UntypedFormBuilder,
    private dialogRef: MatDialogRef<ApplicationGroupPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Dialog<Application>,
    private _applicationServices: ApplicationsService
  ) { }

  ngOnInit(): void {
    this.title = 'GrupoPopUpTitulo'
    this.subtitle = 'GrupoPopUpSubTitulo';
    this.infoText = 'GrupoPopUpInfoText';

    this.form = this.createForm();
    this._userService.getUsers().subscribe(userList => {
      this.userList = userList.filter(u => u.roleName !== "Administrador" && u.roleName !== "Administrador Pro");
      this.userList
        .forEach(u => this.users.push(this._fb.control(u.applications.some(a => a.id === this.data.value.id))));
    });
  }

  onSave() {
    const request = this.userList.map((user, index) => ({ userId: user.id, canAccess: this.users.at(index).value as boolean }));
    
    this._applicationServices
      .grantApplicationAccess(this.data.value.id, request)
      .subscribe(() => this.dialogRef.close(this.data));
  }

  close() {
    this.dialogRef.close(false);
  }

  private createForm(): UntypedFormGroup {
    return this._fb.group({
      users: this._fb.array([])
    });
  }
}

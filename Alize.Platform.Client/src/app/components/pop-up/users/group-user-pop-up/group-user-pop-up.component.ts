import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { RolesService } from 'src/app/pages/administration/roles/roles.service';
import { UsersService } from 'src/app/pages/administration/users/users.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-group-user-pop-up',
  templateUrl: './group-user-pop-up.component.html',
  styleUrls: ['./group-user-pop-up.component.scss']
})
export class GroupUserPopUpComponent {
  title = 'GrupoUserPopUpTitulo';
  subtitle = 'GrupoUserPopUpSubTitulo';
  userForm: FormGroup;
  roles: any;

  constructor(
    private _rolesService: RolesService,
    private _userService: UsersService,
    public dialogRef: MatDialogRef<GroupUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string;
      nombre: string;
      grupos: string;
      mode: ModePopUpType;
    },
    fb: FormBuilder,
    public translate: TranslateService
  ) {
    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
    this.userForm = fb.group({
      roleId: null,
    })
    this._rolesService.getRoles().subscribe(
      (roles) => {
        this.roles = roles
        const currentRole = this.roles.find((role: any) => role.name === this.data.grupos)
        this.userForm.patchValue({
          roleId: currentRole ? currentRole.id : ''
        })
      }
    )
  }

  onClick() {
    let requestApplication = new RequestApplication();
    requestApplication.name = 'Nombre';
    requestApplication.importantInfo = 'Important Info';
    requestApplication.description = 'description';

    this._userService.updateUserRole(this.data.id, this.userForm.value.roleId).subscribe(
      () => {
        this._userService.getUsers();
        this.dialogRef.close();
      },
      (err) => {
        console.log(err)
      })

    this.dialogRef.close(requestApplication);
  }

  close() {
    this.dialogRef.close(false);
  }

  isChecked() {

  }
}

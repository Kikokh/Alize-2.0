import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Company } from 'src/app/models/company.model';
import { User } from 'src/app/models/users.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { UsersService } from 'src/app/pages/administration/users/users.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-user-pop-up',
  templateUrl: './user-pop-up.component.html',
  styleUrls: ['./user-pop-up.component.scss']
})
export class UserPopUpComponent {
  title = 'NuevoUsuario';
  userForm: FormGroup;

  public get ModePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }
  companies: Company[];
  constructor(
    private _companyService: CompaniesService,
    private _userService: UsersService,
    public dialogRef: MatDialogRef<UserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string;
      nombre: string;
      apellidos: string;
      email: string;
      empresa: string;
      grupos: Date;
      isActive: boolean;
      mode: ModePopUpType;
    },
    public translate: TranslateService
  ) {
    this._companyService.getCompanies().subscribe(
      companies => this.companies = companies
    );

    this.title = (this.data.mode === ModePopUpType.ADD) ? 'NuevoUsuario' : (this.data.mode) ? 'VerUsuario' : 'EditarUsuario';
    this.userForm = new FormGroup({
      firstName: new FormControl({ value: (data?.nombre) ? data.nombre : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      lastName: new FormControl({ value: (this.data?.apellidos) ? this.data.apellidos : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      email: new FormControl({ value: (this.data?.email) ? this.data.email : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      company: new FormControl({ value: (this.data.empresa) ? this.data.empresa : '' }),
      password: new FormControl({ value: '' }),
      repassword: new FormControl({ value: '' }),
      groups: new FormControl({ value: (this.data?.grupos) ? this.data.grupos : '', disabled: true }),
      isActive: new FormControl({ value: this.data?.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
    });
  }

  onClick() {
    this.dialogRef.close(this.buildUser());
  }

  private buildUser(): User {
    const value = this.userForm.value;
    let user = new User();
    user.id = this.data.id;
    user.email = value.email;
    
    if (this.data.mode === ModePopUpType.ADD) { 
      user.password = value.password;
    }

    user.firstName = value.firstName;
    user.lastName = value.lastName;
    user.isActive = value.isActive;
    user.action = (this.data.mode === ModePopUpType.ADD) ? ModePopUpType.ADD : ModePopUpType.EDIT;
    return user;
  }

  close() {
    this.dialogRef.close(false);
  }

}
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { Company } from 'src/app/models/company.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { UsersService } from 'src/app/pages/administration/users/users.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-user-pop-up',
  templateUrl: './user-pop-up.component.html',
  styleUrls: ['./user-pop-up.component.scss']
})
export class UserPopUpComponent {
  title ='NuevoUsuario';
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
    this._companyService.companies_shared.subscribe(
      companies => this.companies = companies
    );
    this._companyService.getCompanies();

    this.title = (this.data.mode === ModePopUpType.ADD) ? 'NuevoUsuario' : (this.data.mode) ? 'VerUsuario' : 'EditarUsuario';
    this.userForm = new FormGroup({
      firstName: new FormControl({ value: (data?.nombre) ? data.nombre : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      lastName: new FormControl({ value: (this.data?.apellidos) ? this.data.apellidos : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      email: new FormControl({ value: (this.data?.email) ? this.data.email : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      company: new FormControl({ value: (this.data.empresa) ? this.data.empresa : ''}),
      password: new FormControl({ value: ''}),
      repassword: new FormControl({ value: ''}),
      groups: new FormControl({ value: (this.data?.grupos) ? this.data.grupos : '', disabled: true }),
      isActive: new FormControl({ value: this.data?.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
    });
  }

  onClick() {
    let requestApplication = new RequestApplication();
    requestApplication.name = 'Nombre';
    requestApplication.importantInfo = 'Important Info';
    requestApplication.description = 'description';

    if(this.data.mode === ModePopUpType.ADD) {
      const value = this.userForm.value;
      const request = {
        email: value.email,
        password: value.password,
        firstName: value.firstName,
        lastName: value.lastName
      }
      this._userService.createNewUser(request).subscribe(
        () => {
          this._userService.getUsers();
          this.dialogRef.close();
      },
        (err) => {
          console.log(err)
        })
    } else {
      const value = this.userForm.value;
      const request = {
        id: this.data.id,
        email: value.email,
        firstName: value.firstName,
        lastName: value.lastName,
        isActive: value.isActive
      }
       this._userService.updateUser(this.data.id, request).subscribe(
        () => {
          this._userService.getUsers();
          this.dialogRef.close();
      },
        (err) => {
          console.log(err)
        })
    }

    
    this.dialogRef.close(requestApplication);
  }

  close() {
    this.dialogRef.close(false);
  }

}

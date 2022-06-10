import { Component, Inject, OnDestroy } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { RequestApplication } from 'src/app/components/models/application.model';
import { Roles } from 'src/app/components/models/column.models';
import { Company } from 'src/app/models/company.model';
import { User } from 'src/app/models/users.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { RolesService } from 'src/app/pages/administration/roles/roles.service';
import { UsersService } from 'src/app/pages/administration/users/users.service';
import { SnackbarService } from 'src/app/services/snackbar.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-user-pop-up',
  templateUrl: './user-pop-up.component.html',
  styleUrls: ['./user-pop-up.component.scss'],
})
export class UserPopUpComponent implements OnDestroy {
  title = 'NuevoUsuario';
  userForm: FormGroup;

  private unsubscribeAll = new Subject<any>();

  public get ModePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  companies: Company[];
  roles: Roles[];

  constructor(
    private _companyService: CompaniesService,
    private _userService: UsersService,
    private _rolesService: RolesService,
    public dialogRef: MatDialogRef<UserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      id: string;
      nombre: string;
      apellidos: string;
      email: string;
      empresa: string;
      empresaId: string;
      roleName: string;
      roleId: string;
      grupos: Date;
      isActive: boolean;
      mode: ModePopUpType;
    },
    public translate: TranslateService,
    public fb: FormBuilder,
    public snackBar: SnackbarService
  ) {
    this._companyService
      .getCompanies()
      .subscribe((companies) => (this.companies = companies));

    this._rolesService
      .getRoles()
      .subscribe((roles) => (this.roles = roles));

    this.title =
      this.data.mode === ModePopUpType.ADD
        ? 'NuevoUsuario'
        : this.data.mode
          ? 'VerUsuario'
          : 'EditarUsuario';

    this.buildForm();

    if (this.data.mode === ModePopUpType.EDIT) {
      this.userForm.controls['company'].clearValidators();
      this.userForm.controls['company'].updateValueAndValidity();

      this.userForm.controls['role'].clearValidators();
      this.userForm.controls['role'].updateValueAndValidity();

      this.userForm.controls['password'].clearValidators();
      this.userForm.controls['password'].updateValueAndValidity();
    }

    console.log('El role es: ' , this.data?.roleName);
    console.log('El role es: ' , this.data?.empresaId);
  }

  buildForm() {
    this.userForm = this.fb.group(
      {
        firstName: new FormControl(
          {
            value: this.data?.nombre || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required, Validators.maxLength(100)]
        ),
        lastName: new FormControl(
          {
            value: this.data?.apellidos || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required, Validators.maxLength(100)]
        ),
        email: new FormControl(
          {
            value: this.data?.email || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required, Validators.maxLength(100), Validators.email]
        ),
        company: new FormControl(
          { value:  this.data?.empresaId, disabled: this.data.mode === ModePopUpType.DISPLAY },
          [Validators.required]
        ),
        role: new FormControl(
          { value:  this.data?.roleId, disabled: this.data.mode === ModePopUpType.DISPLAY },
          [Validators.required]
        ),
        password: new FormControl(
          {
            value: null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [
            Validators.required,
            Validators.minLength(8),
            Validators.pattern(
              /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/
            ),
          ]
        ),
        repassword: new FormControl({
          value: null,
          disabled: this.data.mode === ModePopUpType.DISPLAY,
        }),
        groups: new FormControl({ value: this.data?.grupos, disabled: true }),
        isActive: new FormControl({
          value: this.data?.isActive,
          disabled: this.data.mode === ModePopUpType.DISPLAY,
        }),
      },
      { validators: this.matchPassword }
    );
  }

  ngOnDestroy(): void {
    this.unsubscribeAll.next();
    this.unsubscribeAll.complete();
  }

  matchPassword(group: AbstractControl) {

    let password: string = group.get('password')?.value;
    let repassword: string = group.get('repassword')?.value;

    if (!password || !repassword) {
      return null;
    }

    if (password.localeCompare(repassword) != 0) {
      group.get('repassword')?.setErrors({ mismatch: true });
      return { mismatch: true };
    } else {
      return null;
    }
  }

  onClick() {
    this.dialogRef.close(this.buildUser());
  }

  private buildUser(): User {
    let user = new User();

    const value = this.userForm.value;
    user.email = value.email,
      user.password = value.password,
      user.firstName = value.firstName,
      user.lastName = value.lastName,
      user.companyId = value.company,
      user.roleId = value.role,
      user.isActive = value.isActive ? true : false

    if (this.data.mode === ModePopUpType.ADD) {
      user.action = ModePopUpType.ADD;
    } else {
      user.action = ModePopUpType.EDIT;
      user.id = this.data.id;
    }
    return user;
  }

  close() {
    this.dialogRef.close(false);
  }
}

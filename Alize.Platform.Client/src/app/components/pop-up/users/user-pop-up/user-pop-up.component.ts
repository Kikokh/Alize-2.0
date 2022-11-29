import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import {
  AbstractControl,
  UntypedFormBuilder,
  UntypedFormControl,
  UntypedFormGroup,
  Validators
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Observable, Subject } from 'rxjs';
import { Roles } from 'src/app/constants/roles.constants';
import { Company } from 'src/app/models/company.model';
import { Role } from "src/app/models/role.model";
import { User } from 'src/app/models/users.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { RolesService } from 'src/app/pages/administration/roles/roles.service';
import { LoginService } from 'src/app/pages/login/services/login.service';
import { SnackbarService } from 'src/app/services/snackbar.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-user-pop-up',
  templateUrl: './user-pop-up.component.html',
  styleUrls: ['./user-pop-up.component.scss'],
})
export class UserPopUpComponent implements OnInit, OnDestroy {
  title = 'NuevoUsuario';
  userForm: UntypedFormGroup;

  private unsubscribeAll = new Subject<any>();

  public get ModePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  companies: Company[];
  roles: Role[];
  userRole?: Roles;

  get filteredRoles(): Role[] {
    return this.roles?.filter(r => this.data.mode === ModePopUpType.DISPLAY || this.userRole === Roles.AdminPro || r.name !== Roles.Distributor.toString())
  }

  constructor(
    private _companyService: CompaniesService,
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
    public fb: UntypedFormBuilder,
    public snackBar: SnackbarService,
    private _loginService: LoginService
  ) {
  }

  ngOnInit(): void {
    this._companyService
      .getCompanies()
      .subscribe((companies) => (this.companies = companies));

    this._rolesService
      .getRolesForUser()
      .subscribe((roles) => (this.roles = roles));

    this.title =
      this.data.mode === ModePopUpType.ADD
        ? 'NuevoUsuario'
        : this.data.mode
          ? 'VerUsuario'
          : 'EditarUsuario';

    this.buildForm();

    this._loginService.$roleName.subscribe(role => this.userRole = role);

    if (this.data.mode === ModePopUpType.EDIT) {
      this.userForm.controls['company'].clearValidators();
      this.userForm.controls['company'].updateValueAndValidity();

      this.userForm.controls['role'].clearValidators();
      this.userForm.controls['role'].updateValueAndValidity();

      this.userForm.controls['password'].clearValidators();
      this.userForm.controls['password'].updateValueAndValidity();
    }
  }

  buildForm() {
    this.userForm = this.fb.group(
      {
        firstName: new UntypedFormControl(
          {
            value: this.data?.nombre || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required, Validators.maxLength(100)]
        ),
        lastName: new UntypedFormControl(
          {
            value: this.data?.apellidos || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required, Validators.maxLength(100)]
        ),
        email: new UntypedFormControl(
          {
            value: this.data?.email || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required, Validators.maxLength(100), Validators.email]
        ),
        company: new UntypedFormControl(
          { value: this.data?.empresaId || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required]
        ),
        role: new UntypedFormControl(
          { value: this.data?.roleId || null,
            disabled: this.data.mode === ModePopUpType.DISPLAY,
          },
          [Validators.required]
        ),
        password: new UntypedFormControl(
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
        repassword: new UntypedFormControl({
          value: null,
          disabled: this.data.mode === ModePopUpType.DISPLAY,
        }),
        groups: new UntypedFormControl({ value: this.data?.grupos, disabled: true }),
        isActive: new UntypedFormControl({
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

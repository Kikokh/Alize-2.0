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
import { Company } from 'src/app/models/company.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
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
  constructor(
    private _companyService: CompaniesService,
    private _userService: UsersService,
    public dialogRef: MatDialogRef<UserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      id: string;
      nombre: string;
      apellidos: string;
      email: string;
      empresa: string;
      empresaId: string;
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

    this.title =
      this.data.mode === ModePopUpType.ADD
        ? 'NuevoUsuario'
        : this.data.mode
        ? 'VerUsuario'
        : 'EditarUsuario';

    this.buildForm();
    console.log(this.data);

    if (this.data.mode === ModePopUpType.EDIT) {
      this.userForm.controls['company'].clearValidators();
      this.userForm.controls['company'].updateValueAndValidity();

      this.userForm.controls['password'].clearValidators();
      this.userForm.controls['password'].updateValueAndValidity();
    }
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
          { value: null, disabled: this.data.mode === ModePopUpType.DISPLAY },
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
    if (this.userForm.valid) {
      let requestApplication = new RequestApplication();
      requestApplication.name = 'Nombre';
      requestApplication.importantInfo = 'Important Info';
      requestApplication.description = 'description';

      if (this.data.mode === ModePopUpType.ADD) {
        const value = this.userForm.value;
        const request = {
          email: value.email,
          password: value.password,
          firstName: value.firstName,
          lastName: value.lastName,
          companyId: value.company,
          isActive: value.isActive ? true:false
        };
        this.saveUser(request);
      } else {
        const value = this.userForm.value;
        const request = {
          id: this.data.id,
          email: value.email,
          firstName: value.firstName,
          lastName: value.lastName,
          isActive: value.isActive,
        };
        this.updateUser(this.data.id, request);
      }
    } else {
      this.userForm.markAllAsTouched();
    }
  }

  saveUser(request: any) {
    this._userService
      .createNewUser(request)
      .pipe(takeUntil(this.unsubscribeAll))
      .subscribe(
        () => {
          this.snackBar.open('success.saveUser', 'success');
          this.dialogRef.close();
        },
        (err) => this.snackBar.open('errors.saveUser', 'error')
      );
  }

  updateUser(id: string, request: any) {
    this._userService
      .updateUser(id, request)
      .pipe(takeUntil(this.unsubscribeAll))
      .subscribe(
        () => {
          this.snackBar.open('success.updateUser', 'success');
          this.dialogRef.close();
        },
        (err) => this.snackBar.open('errors.updateUser', 'error')
      );
  }

  close() {
    this.dialogRef.close(false);
  }
}

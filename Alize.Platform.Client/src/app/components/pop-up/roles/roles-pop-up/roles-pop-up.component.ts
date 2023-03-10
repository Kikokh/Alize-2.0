import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Subject } from 'rxjs';
import { switchMap, takeUntil } from 'rxjs/operators';
import { Module } from 'src/app/models/module.model';
import { User } from 'src/app/models/user.model';
import { RolesService } from 'src/app/pages/administration/roles/roles.service';
import { LoginService } from 'src/app/pages/login/services/login.service';
import { ModulesService } from '../../../../pages/administration/modules/modules.service';
import { ModePopUpType } from '../../models/entity-type.enum';

export interface IMenuItem {
  isChecked: boolean;
  moduleOpt: string;
}

export interface IAvailablesModules {
  moduleName: string;
  menu: IMenuItem[];
}

@Component({
  selector: 'app-groups-pop-up',
  templateUrl: './roles-pop-up.component.html',
  styleUrls: ['./roles-pop-up.component.scss'],
})
export class RolesPopUpComponent implements OnInit, OnDestroy {
  title = 'RolesPopUpTitulo';
  availableModules = 'GruposModulosHabilitados';
  form: UntypedFormGroup;

  public moduleList: Module[];
  public modules: string[];
  public modulesToSend: Module[];

  private roles = ['Administrador Pro', 'Distribuidor', 'Administrador'];
  private unsubscribeAll = new Subject<any>();

  constructor(
    public dialogRef: MatDialogRef<RolesPopUpComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      id: string;
      nombre: string;
      descripcion: string;
      grupos: string;
      mode: string;
      date: Date;
      activo: boolean;
      modulos: Module[];
    },
    public translate: TranslateService,
    public modulesService: ModulesService,
    public rolesService: RolesService,
    public _loginService: LoginService
  ) {  }

  ngOnInit(): void {
    const lang = localStorage.getItem('lang');
    this.requestApi();
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }

    this.modules = this.data.modulos.map((mod) => mod.id);
    this.modulesToSend = this.data.modulos;

    this.form = new UntypedFormGroup({
      name: new UntypedFormControl({
        value: this.data.nombre ? this.data.nombre : '',
        disabled: this.data.mode === ModePopUpType.DISPLAY,
      }),
      description: new UntypedFormControl({
        value: this.data.descripcion ? this.data.descripcion : '',
        disabled: this.data.mode === ModePopUpType.DISPLAY,
      }),
      active: new UntypedFormControl({
        value: this.data.activo ? this.data.activo : '',
        disabled: false,
      }),
    });
  }

  ngOnDestroy(): void {
    this.unsubscribeAll.next();
    this.unsubscribeAll.complete();
  }

  requestApi() {
    this.modulesService
      .getModules()
      .pipe(
        switchMap((modules) => {
          this.moduleList = modules;
          return this._loginService.$me
        }),
        takeUntil(this.unsubscribeAll)
      )
      .subscribe((me) => {
        const canPermit = this.verifyPermit(me);
        if (canPermit) {
          this.form.controls['active'].enable();
        } else {
          this.form.controls['active'].disable();
        }
      });
  }

  verifyPermit(user: User) {
    const userRole = this.roles.findIndex(f => f.toLowerCase() === user.roleName.toLowerCase());
    if (userRole < 0) return false;
    const currentRole = this.roles.findIndex(f => f.toLowerCase() === this.data.nombre.toLowerCase());
    if (currentRole >= 0 && currentRole < userRole) return false;
    return true;
  }

  onClick() {
    this.rolesService
      .updateRole(this.data.id, this.form.value.active)
      .subscribe(
        () => {
          this.dialogRef.close();
        },
        (err) => {
        }
      );
  }

  close() {
    this.dialogRef.close(false);
  }
}

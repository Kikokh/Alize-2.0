import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { ModePopUpType } from '../../models/entity-type.enum';
import { ModulesService } from "../../../../pages/administration/modules/modules.service";
import { RolesService } from "../../../../pages/administration/roles/services/roles.service";
import { Module } from 'src/app/models/module.model';


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
  styleUrls: ['./roles-pop-up.component.scss']
})
export class RolesPopUpComponent {
  title = 'RolesPopUpTitulo';
  availableModules = 'GruposModulosHabilitados';
  form: FormGroup;

  public moduleList: Module[];
  public modules: string[]
  public modulesToSend: Module[]

  constructor(
    public dialogRef: MatDialogRef<RolesPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string;
      nombre: string;
      descripcion: string;
      grupos: string;
      mode: string;
      date: Date;
      activo: boolean;
      modulos: Module[]
    },
    public translate: TranslateService,
    public modulesService: ModulesService,
    public rolesService: RolesService
  ) {
    const lang = localStorage.getItem('lang');
    modulesService.getModules().subscribe((modules) => this.moduleList = modules)
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }

    this.modules = this.data.modulos.map((mod) => mod.id)
    this.modulesToSend = this.data.modulos

    this.form = new FormGroup({
      name: new FormControl({ value: (this.data.nombre) ? this.data.nombre : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      description: new FormControl({ value: (this.data.descripcion) ? this.data.descripcion : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      active: new FormControl({ value: (this.data.activo) ? this.data.activo : '', disabled: false }),
    });
  }

  onClick() {
    this.rolesService.updateRole(this.data.id, this.form.value.active).subscribe(
      () => {
        this.dialogRef.close();
    },
      (err) => {
        console.log(err)
      })
  }

  close() {
    this.dialogRef.close(false);
  }
}

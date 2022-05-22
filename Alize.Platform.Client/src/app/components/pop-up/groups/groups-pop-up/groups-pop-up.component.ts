import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
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
  templateUrl: './groups-pop-up.component.html',
  styleUrls: ['./groups-pop-up.component.scss']
})
export class GroupsPopUpComponent {
  title = 'GruposPopUpTitulo';
  availableModules = 'GruposModulosHabilitados';
  form: FormGroup;

  public moduleList: IAvailablesModules[];

  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  constructor(
    public dialogRef: MatDialogRef<GroupsPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      grupos: string;
      mode: string;
      date: Date;
      activo: boolean;
    },
    public translate: TranslateService) {
    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
    this.form = new FormGroup({
      name: new FormControl({ value: (this.data.nombre) ? this.data.nombre : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      description: new FormControl({ value: (this.data.grupos) ? this.data.grupos : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      active: new FormControl({ value: (this.data.activo) ? this.data.activo : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
    });

    this.moduleList = [
      {
        moduleName: 'Administracion',
        menu: [
          {
            isChecked: true,
            moduleOpt: 'Aplicaciones'
          },
          {
            isChecked: true,
            moduleOpt: 'Empresas'
          },
          {
            isChecked: true,
            moduleOpt: 'Grupos'
          },
          {
            isChecked: true,
            moduleOpt: 'Módulos'
          },
          {
            isChecked: true,
            moduleOpt: 'Usuarios'
          }
        ]
      },
      {
        moduleName: 'Gestión',
        menu: [
          {
            isChecked: false,
            moduleOpt: 'Alertas'
          },
          {
            isChecked: false,
            moduleOpt: 'Consultas'
          },
          {
            isChecked: false,
            moduleOpt: 'Panel de control'
          }
        ]
      },
      {
        moduleName: 'Informes',
        menu: [
          {
            isChecked: true,
            moduleOpt: 'Auditoría usuarios'
          },
          {
            isChecked: true,
            moduleOpt: 'Registro transacciones'
          }
        ]
      }
    ]
  }

  onClick() {
    let requestApplication = new RequestApplication();
    requestApplication.name = 'Nombre';
    requestApplication.importantInfo = 'Important Info';
    requestApplication.description = 'description';
    this.dialogRef.close(requestApplication);
  }

  close() {
    this.dialogRef.close(false);
  }
}

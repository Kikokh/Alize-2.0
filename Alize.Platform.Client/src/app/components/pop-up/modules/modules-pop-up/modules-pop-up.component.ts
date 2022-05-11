import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-modules-pop-up',
  templateUrl: './modules-pop-up.component.html',
  styleUrls: ['./modules-pop-up.component.scss']
})
export class ModulesPopUpComponent {
  title = 'VerModulo';
  modulesForm: FormGroup;

  constructor( 
    public dialogRef: MatDialogRef<ModulesPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      description: string;
      grupo: string;
      mode: string;
      isActive: boolean;
    },
    public translate: TranslateService) { 
      const lang = localStorage.getItem('lang');
      if (lang !== null) {
        this.translate.setDefaultLang(lang);
      } else {
        this.translate.setDefaultLang('en');
      }
      
      this.modulesForm = new FormGroup({
        name: new FormControl({ value: this.data.nombre, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        description: new FormControl({ value: this.data.description, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        grupo: new FormControl({ value: this.data.grupo, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        controlador: new FormControl({value: 'Alerts', disabled: (this.data.mode === ModePopUpType.DISPLAY)}),
        active: new FormControl({ value: this.data.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      });
    }
  
    close() {
      this.dialogRef.close(false);
    }
}

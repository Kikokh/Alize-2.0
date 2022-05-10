import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RequestApplication } from 'src/app/components/models/application.model';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-modules-pop-up',
  templateUrl: './modules-pop-up.component.html',
  styleUrls: ['./modules-pop-up.component.scss']
})
export class ModulesPopUpComponent {
  title = 'Ver Modulo';
  modulesForm: FormGroup;

  constructor( 
    public dialogRef: MatDialogRef<ModulesPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      description: string;
      grupo: string;
      mode: string;
      isActive: boolean;

    }) { 
      this.modulesForm = new FormGroup({
        name: new FormControl({ value: this.data.nombre, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        description: new FormControl({ value: this.data.description, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        grupo: new FormControl({ value: this.data.grupo, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        controlador: new FormControl({value: 'Alerts', disabled: (this.data.mode === ModePopUpType.DISPLAY)}),
        active: new FormControl({ value: this.data.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      });
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

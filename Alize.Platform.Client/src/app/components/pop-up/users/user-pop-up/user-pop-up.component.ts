import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RequestApplication } from 'src/app/components/models/application.model';
import { ModePopUpType } from '../../modules/entity-type.enum';

@Component({
  selector: 'app-user-pop-up',
  templateUrl: './user-pop-up.component.html',
  styleUrls: ['./user-pop-up.component.scss']
})
export class UserPopUpComponent implements OnInit {
  title ='Nuevo Usuario';
  userForm: FormGroup;
  

  public get ModePopUpType(): typeof ModePopUpType {
    return ModePopUpType; 
  }

  constructor(
    public dialogRef: MatDialogRef<UserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      apellidos: string;
      email: string;
      empresa: string;
      grupos: Date;
      isActive: boolean;
      mode: ModePopUpType;
    }
  ) { 
    this.userForm = new FormGroup({
      name: new FormControl({ value: (this.data?.nombre) ? data.nombre : '', disabled: (data.mode === ModePopUpType.DISPLAY) }),
      lastName: new FormControl({ value: (this.data?.apellidos) ? data.apellidos : '', disabled: (data.mode === ModePopUpType.DISPLAY) }),
      email: new FormControl({ value: (this.data?.email) ? data.email : '', disabled: (data.mode === ModePopUpType.DISPLAY) }),
      company: new FormControl({ value: (this.data.empresa) ? data.empresa : '', disabled: true }),
      groups: new FormControl({ value: (this.data?.grupos) ? data.grupos : '', disabled: true }),
      active: new FormControl({ value: this.data?.isActive, disabled: (data.mode === ModePopUpType.DISPLAY) }),
    });
  }

  ngOnInit(): void {
    console.log();
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

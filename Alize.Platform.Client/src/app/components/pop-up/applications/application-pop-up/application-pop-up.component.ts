import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Application, RequestApplication } from '../../../models/application.model';
import { IUser } from '../../models/IUser';
import { EntityType, ModePopUpType } from '../../models/entity-type.enum';
import { UserService } from '../../services/user.service';
import { ApplicationsService } from 'src/app/pages/administration/applications/services/applications.service';

@Component({
  selector: 'app-application-pop-up',
  templateUrl: './application-pop-up.component.html',
  styleUrls: ['./application-pop-up.component.scss']
})
export class ApplicationPopUpComponent {

  title = '';
  subtitle = '';
  infoText = '';

  applicationForm: FormGroup;

  userList: IUser[];

  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  constructor(
    private _userService: UserService,
    public dialogRef: MatDialogRef<ApplicationPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string;
      name: string;
      description: string;
      importantInfo: string;
      mode: string;
      creationDate: Date;
      isActive: boolean;
    }, 
    public translate: TranslateService,
    private _applicationServices: ApplicationsService) {
    
    this.applicationForm = new FormGroup({
      name: new FormControl({ value: (this.data.name) ? this.data.name : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      description: new FormControl({ value: (this.data.description) ? this.data.description : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      importantInfo: new FormControl({ value: (this.data.importantInfo) ? this.data.importantInfo : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      date: new FormControl({ value: this.data.creationDate, disabled: true }),
      active: new FormControl({ value: this.data.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
    });

    let requestApplication = new RequestApplication();
    requestApplication.name = data.name;
    requestApplication.description = data.description;
    requestApplication.importantInfo = data.importantInfo;

    if (data.mode === ModePopUpType.DISPLAY) {
      this.title = 'DisplayTitulo'
    } if (data.mode === ModePopUpType.EDIT) {
      this.title = 'EditTitulo'
    } else if (data.mode === ModePopUpType.ADD) {
      this.title = 'AddTitulo';
      this.subtitle = 'AddSubTitulo';
    }

    this._userService.getUserPopUp().subscribe(userList => {
      this.userList = userList;
    });

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
  }

  onClick() {
    if (this.data.mode === ModePopUpType.ADD) {
      
      let app = this.buildApplication();
      console.log(app);
      
      this._applicationServices.newApplication(app).subscribe(
        () => {
          this.dialogRef.close();
        },
        (err) => {
          console.log(err);
        }
      );
    } else if (this.data.mode === ModePopUpType.EDIT) {
      
      let app = this.buildApplication();
      
      console.log(app);
      
      this._applicationServices.updateApplication(app).subscribe(
        () => {
          this.dialogRef.close();
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }

  close() {
    this.dialogRef.close(false);
  }

  private buildApplication(): Application {
    let app = new Application; 
    if (this.data.mode === ModePopUpType.ADD) {
      app.name = this.applicationForm.value.name;
      app.description = this.applicationForm.value.description;
      app.dataType = this.applicationForm.value.importantInfo;

      return app;
    }
    else {
      app.id = this.data.id;
      app.name = this.applicationForm.value.name;
      app.description = this.applicationForm.value.description;
      app.dataType = this.data.importantInfo;
      app.isActive = this.applicationForm.value.active;
      app.creationDate = this.data.creationDate;

      return app;
    }    
  }
}

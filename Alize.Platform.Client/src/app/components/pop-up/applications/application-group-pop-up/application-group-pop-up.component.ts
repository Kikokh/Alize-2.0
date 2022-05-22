import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { ApplicationsService } from 'src/app/pages/administration/applications/services/applications.service';
import { IUser, UserResponse } from '../../models/IUser';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-application-group-pop-up',
  templateUrl: './application-group-pop-up.component.html',
  styleUrls: ['./application-group-pop-up.component.scss']
})
export class ApplicationGroupPopUpComponent {

  title = '';
  subtitle = '';
  infoText = '';
  userList: UserResponse[];

  constructor(  
    private _userService: UserService,
    public dialogRef: MatDialogRef<ApplicationGroupPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      Id: string;
      nombre: string;
      description: string;
      importantInfo: string;
      mode: string;
      date: Date;
      isActive: boolean;
    },
    public translate: TranslateService,
    private _applicationService: ApplicationsService) {
      
    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
    this.title = 'GrupoPopUpTitulo'
    this.subtitle = 'GrupoPopUpSubTitulo';
    this.infoText = 'GrupoPopUpInfoText';
    
    this._userService.getUsers().subscribe(userList => {
      let filterUsers = userList.filter( u => u.roleName != "Distribuidor" && u.roleName != "Administrador Pro");
      this.userList = filterUsers;
    });

    //this._applicationService.getApplication(this.data.id)
    this._applicationService.getApplication("64690af6-fda3-489c-4798-08da280318de").subscribe( user => {
      console.log(user);
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

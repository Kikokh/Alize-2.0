import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { Company } from 'src/app/models/company.model';
import { Module } from 'src/app/models/module.model';
import { ApplicationGroupPopUpComponent } from '../applications/application-group-pop-up/application-group-pop-up.component';
import { ApplicationPopUpComponent } from '../applications/application-pop-up/application-pop-up.component';
import { CompanyPopUpComponent } from '../companies/company-pop-up/company-pop-up.component';
import { EncryptionPopUpComponent } from '../encryption-pop-up/encryption-pop-up.component';
import { EntityType, ModePopUpType } from '../models/entity-type.enum';
import { MatDialogConfigModel } from '../models/request-pop-up.model';
import { ModulesPopUpComponent } from '../modules/modules-pop-up/modules-pop-up.component';
import { RolesPopUpComponent } from '../roles/roles-pop-up/roles-pop-up.component';
import { DeleteUserPopUpComponent } from '../users/delete-user-pop-up/delete-user-pop-up.component';
import { GroupUserPopUpComponent } from '../users/group-user-pop-up/group-user-pop-up.component';
import { PasswordUserPopUpComponent } from '../users/password-user-pop-up/password-user-pop-up.component';
import { TimerPopUpComponent } from '../users/timer-pop-up/timer-pop-up.component';
import { UserPopUpComponent } from '../users/user-pop-up/user-pop-up.component';

@Injectable({
  providedIn: 'root'
})
export class OpenPopUpService {
  private dialogRef: MatDialogRef<any>;

  constructor(private dialog: MatDialog) { }

  open(entity: EntityType, mode: ModePopUpType, data?: any): Observable<any> {
    const matDialogConfigModel = this.resolveComponentToOpen(entity, mode, data);
    this.dialogRef = this.dialog.open(matDialogConfigModel.component, {
      data: matDialogConfigModel.data,
    });

    return this.dialogRef.afterClosed()
      .pipe(
        take(1)
      );
  }

  close() {
    if (this.dialogRef && this.dialogRef.componentInstance) { this.dialogRef.close(true); }
  }

  // MatDialogConfigModel
  resolveComponentToOpen(entity: EntityType, mode: ModePopUpType, data?: any): MatDialogConfigModel {
    let matDialogConfigModel = new MatDialogConfigModel();
    matDialogConfigModel.entity = entity;
    matDialogConfigModel.mode = mode;

    switch (entity) {
      case EntityType.USERS: {
        this.resolveUserPopUp(mode, matDialogConfigModel, data);
        break;
      }
      case EntityType.APPLICATIONS: {
        this.resolveApplicationPopUp(mode, matDialogConfigModel, data);
        break;
      }
      case EntityType.ROLES: {
        this.resolveRolesPopUp(mode, matDialogConfigModel, data);
        break;
      }
      case EntityType.MODULES: {
        this.resolveModulesPopUp(mode, matDialogConfigModel, data);
        break;
      }
      case EntityType.COMPANIES: {
        this.resolveCompaniesPopUp(mode, matDialogConfigModel, data);
        break;
      }
      case EntityType.ENCRYPTING: {
        matDialogConfigModel.component = EncryptionPopUpComponent;
        matDialogConfigModel.data = {
          hash: data.hash,
          data: data.data
        };
        break;
      }
      default: {
        const any: any = null;
        return any;
        //statements;
        break;
      }
    }

    return matDialogConfigModel;
  }


  resolveModulesPopUp(mode: ModePopUpType, matDialogConfigModel: MatDialogConfigModel, data?: Module) {
    switch (mode) {
      case ModePopUpType.DISPLAY: {
        matDialogConfigModel.component = ModulesPopUpComponent;
        matDialogConfigModel.data = {
          nombre: data?.name,
          description: data?.description,
          grupo: data?.moduleGroup,
          activo: data?.isActive,
          mode: mode
        }
        break;
      }
    }
  }

  resolveRolesPopUp(mode: ModePopUpType, matDialogConfigModel: MatDialogConfigModel, data?: any) {

    switch (mode) {
      case ModePopUpType.DISPLAY: {
        matDialogConfigModel.component = RolesPopUpComponent;
        matDialogConfigModel.data = {
          id: data?.id,
          nombre: data?.name,
          grupos: data?.groups,
          descripcion: data?.description,
          activo: data?.isActive,
          modulos: data?.modules,
          mode: mode
        }
        break;
      }
      case ModePopUpType.ADD: {
        matDialogConfigModel.component = RolesPopUpComponent;
        matDialogConfigModel.data = {
          mode: mode
        }
        break;
      }
    }
  }


  resolveApplicationPopUp(mode: ModePopUpType, matDialogConfigModel: MatDialogConfigModel, data?: any) {
    switch (mode) {
      case ModePopUpType.ADD: {
        matDialogConfigModel.data = { mode: mode }
        matDialogConfigModel.component = ApplicationPopUpComponent;
        break;
      }
      case ModePopUpType.EDIT: {
        matDialogConfigModel.component = ApplicationPopUpComponent;
        matDialogConfigModel.data = {
          id: data.id,
          name: data.name,
          description: data.description,
          fecha: new Date(),
          company: data.company,
          creationDate: data.creationDate,
          dataType: data.dataType,
          isActive: data.isActive,
          mode: mode
        }
        break;
      }
      case ModePopUpType.DISPLAY: {
        matDialogConfigModel.component = ApplicationPopUpComponent;
        matDialogConfigModel.data = {
          id: data.id,
          name: data.name,
          description: data.description,
          fecha: new Date(),
          company: data.company,
          creationDate: data.creationDate,
          dataType: data.dataType,
          isActive: data.isActive,
          mode: mode
        }
        break;
      }

      case ModePopUpType.GROUP: {
        matDialogConfigModel.component = ApplicationGroupPopUpComponent;
        matDialogConfigModel.data = {
          value: data,
          nombre: data.Nombre,
          grupos: data.Grupo,
          mode: mode
        }
        break;
      }
    }
  }

  resolveUserPopUp(mode: ModePopUpType, matDialogConfigModel: MatDialogConfigModel, data?: any) {
    switch (mode) {
      case ModePopUpType.ADD: {
        matDialogConfigModel.data = { mode: mode }
        matDialogConfigModel.component = UserPopUpComponent;
        break;
      }
      case ModePopUpType.EDIT: {
        matDialogConfigModel.component = UserPopUpComponent;
        matDialogConfigModel.data = {
          id: data.id,
          nombre: data.firstName,
          apellidos: data.lastName,
          email: data.email,
          empresa: data.companyName,
          grupos: data.roleName,
          isActive: data.isActive,
          empresaId: data.companyId,
          roleName: data.roleName,
          roleId: data.roleId,
          mode: mode,
        };
        break;
      }
      case ModePopUpType.DISPLAY: {
        matDialogConfigModel.component = UserPopUpComponent;
        matDialogConfigModel.data = {
          id: data.id,
          nombre: data.firstName,
          apellidos: data.lastName,
          email: data.email,
          empresa: data.companyName,
          empresaId: data.companyId,
          grupos: data.roleName,
          isActive: data.isActive,
          roleName: data.roleName,
          roleId: data.roleId,
          mode: mode
        }
        break;
      }
      case ModePopUpType.GROUP: {
        matDialogConfigModel.component = GroupUserPopUpComponent;
        matDialogConfigModel.data = {
          id: data.id,
          nombre: data.firstName,
          grupos: data.roleName,
          mode: mode
        }
        break;
      }
      case ModePopUpType.PASSWORD: {
        matDialogConfigModel.component = PasswordUserPopUpComponent;
        matDialogConfigModel.data = {
          id: data.id,
          nombre: data.firstName,
          mode: mode
        }
        break;
      }
      case ModePopUpType.DELETE: {
        matDialogConfigModel.component = DeleteUserPopUpComponent;
        matDialogConfigModel.data = {
          id: data.id,
          nombre: data.Nombre,
        }
        break;
      }
      case ModePopUpType.TIMER: {
        matDialogConfigModel.component = TimerPopUpComponent;
        matDialogConfigModel.data = {
          nombre: data.Nombre,
        }
        break;
      }
    }
  }
  resolveCompaniesPopUp(mode: ModePopUpType, matDialogConfigModel: MatDialogConfigModel, data?: Company) {
    switch (mode) {
      case ModePopUpType.DISPLAY:
        matDialogConfigModel.component = CompanyPopUpComponent;
        matDialogConfigModel.data = {
          id: data?.id,
          name: data?.name,
          description: data?.description,
          isActive: data?.isActive,
          activity: data?.activity,
          businessName: data?.businessName,
          cif: data?.cif,
          comments: data?.comments,
          language: data?.language,
          phoneNumber: data?.phoneNumber,
          email: data?.email,
          web: data?.web,
          contactName: data?.contactName,
          logo: data?.logo,
          imageTypeMime: data?.imageTypeMime,
          address: data?.address,
          zip: data?.zip,
          city: data?.city,
          province: data?.province,
          country: data?.country,
          mode: mode
        }
        break;
      case ModePopUpType.EDIT:
        matDialogConfigModel.component = CompanyPopUpComponent;
        matDialogConfigModel.data = { ...data, mode }
        break;
      case ModePopUpType.ADD:
        matDialogConfigModel.component = CompanyPopUpComponent;
        matDialogConfigModel.data = { ...data, mode }
        break;
    }
  }
}

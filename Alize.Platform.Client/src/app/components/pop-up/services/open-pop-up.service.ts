import { Component, ComponentRef, Injectable, Type } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { IElementDataApp } from '../../models/column.models';
import { ProgressSpinnerComponent } from '../../progress-spinner/progress-spinner.component';
import { EntityType, ModePopUpType } from '../modules/entity-type.enum';
import { MatDialogConfigModel } from '../modules/request-pop-up.model';
import { DeleteUserPopUpComponent } from '../users/delete-user-pop-up/delete-user-pop-up.component';
import { GroupUserPopUpComponent } from '../users/group-user-pop-up/group-user-pop-up.component';
import { PasswordUserPopUpComponent } from '../users/password-user-pop-up/password-user-pop-up.component';
import { UserPopUpComponent } from '../users/user-pop-up/user-pop-up.component';

@Injectable({
  providedIn: 'root'
})
export class OpenPopUpService {
  private dialogRef: MatDialogRef<any>;

  constructor(private dialog: MatDialog) { }

  open(entity: EntityType, mode: ModePopUpType, data?: any) {
    const matDialogConfigModel = this.resolveComponentToOpen(entity, mode, data);
    this.dialogRef = this.dialog.open(matDialogConfigModel.component, {
      data: matDialogConfigModel.data,
    });
  }

  close() {
    if (this.dialogRef && this.dialogRef.componentInstance) { this.dialogRef.close(true); }
  }

  afterClosed(): Observable<any> {
    return this.dialogRef.afterClosed()
      .pipe(
        take(1),
        map(res => {
          return res;
        }));
  }

  // MatDialogConfigModel
  resolveComponentToOpen(entity: EntityType, mode: ModePopUpType, data?: any): MatDialogConfigModel {
    let matDialogConfigModel = new MatDialogConfigModel();
    matDialogConfigModel.entity = entity;
    matDialogConfigModel.mode = mode;

    switch (entity) {
      case EntityType.USERS: {
        switch (mode) {
          case ModePopUpType.ADD: {
            matDialogConfigModel.data = { mode: mode }
            matDialogConfigModel.component = UserPopUpComponent;
            break;
          }
          case ModePopUpType.EDIT: {
            matDialogConfigModel.component = UserPopUpComponent;
            matDialogConfigModel.data = {
              nombre: data.Nombre,
              apellidos: data.Email,
              email: data.Email,
              empresa: data.Empresa,
              grupos: data.Grupo,
              isActive: data.Activo,
              mode: mode
            }
            break;
          }
          case ModePopUpType.DISPLAY: {
            matDialogConfigModel.component = UserPopUpComponent;
            matDialogConfigModel.data = {
              nombre: data.Nombre,
              apellidos: data.Email,
              email: data.Email,
              empresa: data.Empresa,
              grupos: data.Grupo,
              isActive: data.Activo,
              mode: mode
            }
            break;
          }

          case ModePopUpType.GROUP: {
            matDialogConfigModel.component = GroupUserPopUpComponent;
            matDialogConfigModel.data = {
              nombre: data.Nombre,
              grupos: data.Grupo,
              mode: mode
            }
            break;
          }
          case ModePopUpType.PASSWORD: {
            matDialogConfigModel.component = PasswordUserPopUpComponent;
            matDialogConfigModel.data = {
              nombre: data.Nombre,
              mode: mode
            }
            break;
          }
          case ModePopUpType.DELETE: {
            matDialogConfigModel.component = DeleteUserPopUpComponent;
            matDialogConfigModel.data = {
              nombre: data.Nombre,
            }
            break;
          }
        }
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
}

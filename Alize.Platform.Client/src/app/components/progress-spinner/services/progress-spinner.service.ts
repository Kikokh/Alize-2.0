import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ProgressSpinnerComponent } from '../progress-spinner.component';

@Injectable({
  providedIn: 'root'
})
export class ProgressSpinnerService {
  private dialogRef: MatDialogRef<ProgressSpinnerComponent>;

  constructor(private dialog: MatDialog) { }

  open() {
    this.dialogRef = this.dialog.open(ProgressSpinnerComponent, {
      data: {
        panelClass: 'dialog-container-custom' 
      },
    });
  }

  close() {
    if (this.dialogRef && this.dialogRef.componentInstance) { this.dialogRef.close();}
  }

}

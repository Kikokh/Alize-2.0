import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-encryption-pop-up',
  templateUrl: './encryption-pop-up.component.html',
  styleUrls: ['./encryption-pop-up.component.scss']
})
export class EncryptionPopUpComponent {
  hashData: string;

  constructor(
    public dialogRef: MatDialogRef<EncryptionPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      hash: string;
      data: any;
    }
  ) {
    this.hashData = JSON.stringify(this.data.data);
  }

}

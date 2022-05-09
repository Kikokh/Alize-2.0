import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies } from 'src/app/components/models/column.models';
import { EntityType } from 'src/app/components/pop-up/models/entity-type.enum';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.scss']
})
export class ManagementComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];

  public get Entity(): typeof EntityType {
    return EntityType; 
  }
  
  constructor() { }

}

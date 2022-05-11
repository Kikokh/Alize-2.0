import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataApp, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.scss', '../../layout-main.scss']
})
export class ApplicationsComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataApp[];
  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' },
    { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
    { optionName: ModePopUpType.GROUP, icon: 'groups' }
  ]

  public get Entity(): typeof EntityType {
    return EntityType;
  }


  constructor(private _columnBuilderService: ColumnBuilderService) {

    this._columnBuilderService.getApplicationData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }

}

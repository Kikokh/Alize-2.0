import { Component, OnInit } from '@angular/core';
import { IColumnDef, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { Module } from 'src/app/models/module.model';
import { ModulesService } from './modules.service';
@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss', '../../layout-main.scss']
})
export class ModulesComponent implements OnInit {
  displayedColumns: IColumnDef[] = [
    { columnDef: 'Nombre', header: 'Nombre', cell: (element: Module) => `${element.name}` },
    { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: Module) => `${element.description}` },
    { columnDef: 'Grupos', header: 'Grupos', cell: (element: Module) => `${element.moduleGroup}` },
    { columnDef: 'Activo', header: 'Activo', cell: (element: Module) => `${element.isActive}` }
  ];
  elementData: Module[];
  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' }
  ]

  isLoading = true;
  get entity(): EntityType {
    return EntityType.MODULES;
  }

  constructor(private _moduleService: ModulesService) { }

  ngOnInit() {
    this._moduleService.getModules().subscribe(
      modules =>{
        this.isLoading = false; 
        this.elementData = modules; 
      }
    );
  }
}

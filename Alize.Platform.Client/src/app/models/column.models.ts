import { ModePopUpType } from "../components/pop-up/models/entity-type.enum";
import { Role } from "./role.model";


export interface IOperationsModel {
    optionName: ModePopUpType;
    icon: string;
    requiredRoles?: string[]
}

export interface IColumnDef {
    columnDef: string;
    header: string;
    cell: (element: any) => string;
}

export class GridDataRoles {
    columnDef: IColumnDef[];
    data: Role[];
}

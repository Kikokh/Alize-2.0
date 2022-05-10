import { Type } from "@angular/core";
import { MatDialogConfig } from "@angular/material/dialog";
import { EntityType, ModePopUpType } from "./entity-type.enum";

export class RequestPopUpModel {
    entity: string;
    mode:string;
    params: string[];

    resolveRequestPopUpModel(_entity: EntityType, _mode: ModePopUpType): RequestPopUpModel {
        let requestPopUpModel = new RequestPopUpModel();
        requestPopUpModel.entity = _entity;
        requestPopUpModel.entity = _mode;
        // requestPopUpModel.params = _params;

        if (_entity === EntityType.USERS) {
                if (_mode === ModePopUpType.DISPLAY) {
                    // this.createRequest(['','','','',''])
                }
        }

        return requestPopUpModel;
    }

    // createRequest(params: string[]) : MatDialogConfig<any>{
    //     return 
    // }
}


export class MatDialogConfigModel {
    component: Type<any>;
    entity: EntityType;
    mode: ModePopUpType;
    data: any;

    constructor() {}
}
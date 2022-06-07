import { ModePopUpType } from "../../../models/entity-type.enum";

export class PasswordModel {
    userId: string;
    password: string;
    repeatPassword: string;
    action: ModePopUpType;
    constructor() { }
}
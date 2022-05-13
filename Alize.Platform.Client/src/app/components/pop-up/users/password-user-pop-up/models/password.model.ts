import { ModePopUpType } from "../../../models/entity-type.enum";

export class PasswordModel {
    password: string;
    repeatPassword: string;
    mode: ModePopUpType;
    constructor() { }
}
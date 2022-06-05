import { ModePopUpType } from "../components/pop-up/models/entity-type.enum";

export class User {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    companyName: string;
    roleName: string;
    isActive: boolean;
    password: string;
    action: ModePopUpType;
}
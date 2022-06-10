import { ModePopUpType } from "../components/pop-up/models/entity-type.enum";
import { Application } from "./application.model";

export class User {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    companyName: string;
    companyId: string;
    roleId: string;
    roleName: string;
    isActive: boolean;
    password: string;
    action: ModePopUpType;
    applications: Application[];
}
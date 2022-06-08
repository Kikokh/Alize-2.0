import { Application } from "./application.model";
import { Module } from "./module.model";

export class User {
    companyLogo: string;
    companyName: string;
    email: string;
    firstName: string;
    id: string;
    isActive: boolean;
    lastName: string;
    roleName: string;
    userName: string;
    modules: Module[];
    applications: Application[];
}
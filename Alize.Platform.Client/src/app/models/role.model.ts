import { Module } from "./module.model";

export interface Role {
    id: string;
    name: string;
    description: string;
    isActive: boolean;
    modules: Module[];
}

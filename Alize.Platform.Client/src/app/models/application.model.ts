import { Company } from "./company.model";

export class Application {
    id: string;
    name: string;
    description: string;
    companyId: string;
    isActive: true;
    creationDate: Date;
    company?: Company;
    companyName: string;
    dataType?: string;
}
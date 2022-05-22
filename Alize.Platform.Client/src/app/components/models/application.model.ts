import { Company } from "./company.model";

export class RequestApplication {
    id: string;
    name: string;
    description: string;
    importantInfo: string;

    constructor() {
        
    }
}
export class Application {
    id: string;
    name: string;
    description: string;
    companyId: string;
    isActive: boolean;
    creationDate: Date;
    company?: Company;
    companyName: string;
    dataType?: string;
}
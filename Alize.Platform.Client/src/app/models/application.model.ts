import { ModePopUpType } from "../components/pop-up/models/entity-type.enum";
import { Blockchain } from "./blockchain.model";
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
    action: ModePopUpType;
    showChartAction?: boolean
    blockchainId?: string;
    blockchain?: Blockchain;
    importantInfo?: string;
}

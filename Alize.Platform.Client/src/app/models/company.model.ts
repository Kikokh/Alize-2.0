import { ModePopUpType } from "../components/pop-up/models/entity-type.enum";

export class Company {
    activity: string;
    address: string;
    businessName: string;
    cif: string;
    city: string;
    comments?: string;
    contactName: string;
    country: string;
    email: string;
    id: string;
    imageTypeMime?: string;
    isActive: boolean;
    language: string;
    logo: string;
    name: string;
    parentCompanyId?: string;
    parentCompany?: string;
    phoneNumber: string;
    province: string;
    web: string;
    zip: string;
    description: string;
    action: ModePopUpType;
}
export class IUser {
    name: string;
    status: string;

    constructor() {
        
    }
}

export class UserResponse {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    isActive: boolean;
    roleName: string;
    companyName: string;
    companyLogo: string;
}
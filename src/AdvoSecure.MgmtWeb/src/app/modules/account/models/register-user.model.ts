export interface RegisterUserRequest {
    email: string;
    displayName: string;
    password: string;
    firstName: string;
    lastName: string;
    tenantIdentifier?: string;
    setAsAdmin?: boolean;
}

export interface RegisterUserResponse {
    success: boolean;
    message: string;
}

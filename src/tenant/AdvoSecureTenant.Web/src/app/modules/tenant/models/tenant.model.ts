export interface Tenant {
    schemaName: string;
    name: string;
    azureTenantId: string;
    connectionString?: string;
}

export interface CheckTenantExistResponse {
    azureTenantId: string;
    isTenantAdmin: boolean;
    result: boolean;
}

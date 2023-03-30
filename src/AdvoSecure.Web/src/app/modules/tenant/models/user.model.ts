export interface User {
  azureIdentityId: string | undefined;
  azureEmail: string | undefined;
  displayName?: string;
}

export interface OrgInitializationRequest extends User {
  azureTenantId: string;
}

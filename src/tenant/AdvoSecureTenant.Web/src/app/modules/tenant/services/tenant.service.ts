import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from  '../../../../environments/environment';
import { CheckTenantExistResponse, Tenant } from './../models/tenant.model';

@Injectable({
  providedIn: 'root',
})
export class TenantService {
  constructor(private httpClient: HttpClient) {}

  checkTenantExist(tenantId: string): Observable<CheckTenantExistResponse> {
    return this.httpClient.get<CheckTenantExistResponse>(
      `${environment.baseTeantApi}/${environment.tenantApis.checkTenantExist}/${tenantId}`
    );
  }

  checkValidTenant(tenantId: string): Observable<boolean> {
    return this.httpClient.get<boolean>(
      `${environment.baseTeantApi}/${environment.tenantApis.checkValidTenant}/${tenantId}`
    );
  }

  createTenant(tenantId: string): Observable<Tenant> {
    const payload: Tenant = {
      name: `identifier-${tenantId}`,
      schemaName: `db-${tenantId}`,
      azureTenantId: tenantId,
    };
    return this.httpClient.post<Tenant>(
      `${environment.baseTeantApi}/${environment.tenantApis.createTenant}`,
      payload
    );
  }
}

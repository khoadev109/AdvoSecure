import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tenant } from '../models/tenant.model';
import { OrgInitializationRequest } from '../models/user.model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class OrganizationService {
  constructor(private httpClient: HttpClient) {}

  createUser(
    orgInitializationRequest: OrgInitializationRequest
  ): Observable<boolean> {
    return this.httpClient.post<boolean>(
      `${environment.baseAppApi}/${environment.appApis.createUser}`,
      orgInitializationRequest
    );
  }

  createUserOrganization(
    orgInitializationRequest: OrgInitializationRequest
  ): Observable<boolean> {
    return this.httpClient.post<boolean>(
      `${environment.baseAppApi}/${environment.appApis.createUserOrg}`,
      orgInitializationRequest
    );
  }

  getAppTenant(): Observable<Tenant> {
    return this.httpClient.get<Tenant>(
      `${environment.baseAppApi}/${environment.appApis.tenant}`
    );
  }
}

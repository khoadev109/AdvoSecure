import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { TenantUser } from '../models/user.model';
import { RegisterUserRequest, RegisterUserResponse } from '../models/register-user.model';
import { getUserIdentifier } from '../../auth/token-helper';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private API_USERS_URL = `${environment.apiUrl}/tenantaccount/`;

  constructor(private httpClient: HttpClient) {
  }

  registerUser(payload: RegisterUserRequest) : Observable<RegisterUserResponse> {
    const body = JSON.stringify(payload);
    return this.httpClient.post<RegisterUserResponse>(this.API_USERS_URL + 'register-user', body);
  }

  getAllUsers() : Observable<TenantUser[]> {
    return this.httpClient.get<TenantUser[]>(this.API_USERS_URL + 'all-users');
  }

  getTenantProfile(): Observable<TenantUser> {
    const userIdentifier = getUserIdentifier();
    return this.httpClient.get<TenantUser>(this.API_USERS_URL + 'profile/' + userIdentifier);
  }
}

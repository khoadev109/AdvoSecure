import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile } from './../models/profile.model';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class GraphService {
  constructor(private httpClient: HttpClient) {}

  getProfile(): Observable<Profile> {
    return this.httpClient.get(environment.graphProfileApi);
  }

  updateProfile(profile: Profile) {
    const user: User = {
      id: profile.id,
      givenName: profile.givenName,
      surname: profile.surname,
      userPrincipalName: profile.userPrincipalName
    };
    return this.httpClient.patch(`${environment.graphUserApi}/${user.userPrincipalName}`, user);
  }
}

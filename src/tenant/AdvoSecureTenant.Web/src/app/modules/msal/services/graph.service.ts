import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile, AdUser } from './../models/profile.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GraphService {
  constructor(private httpClient: HttpClient) {}

  getProfile(): Observable<Profile> {
    return this.httpClient.get(environment.graphUserApi);
  }

  updateUser(profile: Profile): Observable<Profile> {
    const user = new AdUser(
      profile.givenName,
      profile.surname,
      profile.userPrincipalName
    );
    return this.httpClient.patch(environment.graphUserApi,
      user
    );
  }
}

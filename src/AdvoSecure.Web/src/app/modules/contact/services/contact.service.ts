import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private API_CONTACT_URL = `${environment.apiUrl}/contact`;

  constructor(private httpClient: HttpClient) {
  }

  getContacts(displayName?: string | null) : Observable<Contact[]> {
    displayName = this.getEmptySearchTerm(displayName);

    return this.httpClient.get<Contact[]>(this.API_CONTACT_URL + "/contacts?searchTerm=" + displayName);
  }

  getEmployees(displayName?: string | null) : Observable<Contact[]> {
    displayName = this.getEmptySearchTerm(displayName);

    return this.httpClient.get<Contact[]>(this.API_CONTACT_URL + "/employees?searchTerm=" + displayName || "");
  }

  getPersons(displayName?: string | null) : Observable<Contact[]> {
    displayName = this.getEmptySearchTerm(displayName);

    return this.httpClient.get<Contact[]>(this.API_CONTACT_URL + "/persons?searchTerm=" + displayName || "");
  }

  private getEmptySearchTerm(searchTerm?: string | null) {
    return searchTerm ? searchTerm : "";
  }
}

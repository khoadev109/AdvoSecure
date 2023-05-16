import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';
import { ContactIdType } from '../models/contact-id-type.model';
import { ContactMaritalStatus } from '../models/contact-marital-status.model';
import { ContactLanguage } from '../models/contact-languages.model';
import { ContactTitles } from '../models/contact-titles.model';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private API_CONTACT_URL = `${environment.apiUrl}/contact`;

  constructor(private httpClient: HttpClient) {}

  getContact(id: number): Observable<Contact> {
    return this.httpClient.get<Contact>(this.API_CONTACT_URL + '/' + id);
  }

  getContacts(displayName?: string | null): Observable<Contact[]> {
    displayName = this.getEmptySearchTerm(displayName);

    return this.httpClient.get<Contact[]>(
      this.API_CONTACT_URL + '/list?searchTerm=' + displayName
    );
  }

  getCompanies(displayName?: string | null): Observable<Contact[]> {
    displayName = this.getEmptySearchTerm(displayName);

    return this.httpClient.get<Contact[]>(
      this.API_CONTACT_URL + '/companies?searchTerm=' + displayName
    );
  }

  getEmployees(displayName?: string | null): Observable<Contact[]> {
    displayName = this.getEmptySearchTerm(displayName);

    return this.httpClient.get<Contact[]>(
      this.API_CONTACT_URL + '/employees?searchTerm=' + displayName
    );
  }

  getPersons(displayName?: string | null): Observable<Contact[]> {
    displayName = this.getEmptySearchTerm(displayName);

    return this.httpClient.get<Contact[]>(
      this.API_CONTACT_URL + '/persons?searchTerm=' + displayName
    );
  }

  getIdTypes(): Observable<ContactIdType[]> {
    return this.httpClient.get<ContactIdType[]>(
      this.API_CONTACT_URL + '/id-types'
    );
  }

  getMaritalStatuses(): Observable<ContactMaritalStatus[]> {
    return this.httpClient.get<ContactMaritalStatus[]>(
      this.API_CONTACT_URL + '/marital-statuses'
    );
  }

  getLanguages(): Observable<ContactLanguage[]> {
    return this.httpClient.get<ContactLanguage[]>(
      this.API_CONTACT_URL + '/languages'
    );
  }

  getContactTitle(): Observable<ContactTitles[]> {
    return this.httpClient.get<ContactTitles[]>(
      this.API_CONTACT_URL + '/contact-titles'
    );
  }

  createContact(payload: Contact): Observable<any> {
    const body = JSON.stringify(payload);
    return this.httpClient.post(this.API_CONTACT_URL, body);
  }

  updateContact(id: string, payload: Contact): Observable<any> {
    console.log('update');
    const body = JSON.stringify(payload);
    console.log('body', body);
    return this.httpClient.put(this.API_CONTACT_URL + '/' + id, body);
  }

  private getEmptySearchTerm(searchTerm?: string | null) {
    return searchTerm ? searchTerm : '';
  }
}

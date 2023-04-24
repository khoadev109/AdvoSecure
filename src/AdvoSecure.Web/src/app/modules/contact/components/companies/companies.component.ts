import { ChangeDetectorRef, Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';
import { PagingContactListComponent } from '../../paging-contact-list.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
})
export class CompaniesComponent extends PagingContactListComponent {
  constructor(
    router: Router,
    changeDetectorRef: ChangeDetectorRef,
    contactService: ContactService
  ) {
    super(router, changeDetectorRef, contactService);
  }

  fetchContacts() {
    this.contactService
      .getCompanies(this.searchTerm)
      .subscribe((contacts: Contact[]) => {
        this.POSTS = contacts;
        this.changeDetectorRef.detectChanges();
      });
  }

  redirectToNewCompany() {
    this.router.navigate(['/management/contacts/details'], {
      queryParams: { type: 'company' },
    });
  }

  redirectToExistingCompany(id: number) {
    this.router.navigate(['/management/contacts/details/' + id], {
      queryParams: { type: 'company' },
    });
  }
}

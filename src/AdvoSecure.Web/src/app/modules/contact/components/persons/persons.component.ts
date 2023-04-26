import { ChangeDetectorRef, Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';
import { DomSanitizer } from '@angular/platform-browser';
import { PagingContactListComponent } from '../../paging-contact-list.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
})
export class PersonsComponent extends PagingContactListComponent {
  constructor(
    router: Router,
    changeDetectorRef: ChangeDetectorRef,
    contactService: ContactService,
    sanitizer: DomSanitizer
  ) {
    super(router, changeDetectorRef, contactService, sanitizer);
  }

  fetchData() {
    this.contactService
      .getPersons(this.searchTerm)
      .subscribe((persons: Contact[]) => {
        this.POSTS = persons.map((person) => {
          person.avatar = person.pictureBin
            ? this.sanitizer?.bypassSecurityTrustUrl(
                'data:image/jpeg;base64,' + person.pictureBin
              )
            : './assets/media/avatars/blank.png';
          return person;
        });
        this.changeDetectorRef.detectChanges();
      });
  }

  redirectToNewPerson() {
    this.router.navigate(['/management/contacts/details'], {
      queryParams: { type: 'person' },
    });
  }

  redirectToExistingPerson(id: number) {
    this.router.navigate(['/management/contacts/details/' + id], {
      queryParams: { type: 'person' },
    });
  }
}

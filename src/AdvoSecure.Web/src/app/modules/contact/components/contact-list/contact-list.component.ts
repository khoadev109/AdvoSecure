import { ChangeDetectorRef, Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';
import { DomSanitizer } from '@angular/platform-browser';
import { PagingContactListComponent } from '../../paging-contact-list.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
})
export class ContactListComponent extends PagingContactListComponent {
  constructor(
    router: Router,
    changeDetectorRef: ChangeDetectorRef,
    contactService: ContactService,
    sanitizer: DomSanitizer,
  ) {
    super(router, changeDetectorRef, contactService, sanitizer);
  }

  fetchContacts() {
    this.contactService
      .getContacts(this.searchTerm)
      .subscribe((contacts: Contact[]) => {
        this.POSTS = contacts.map((contact) => {
          contact.avatar = contact.pictureBin
            ? this.sanitizer?.bypassSecurityTrustUrl(
                'data:image/jpeg;base64,' + contact.pictureBin
              )
            : './assets/media/avatars/blank.png';
          return contact;
        });
        this.changeDetectorRef.detectChanges();
      });
  }
}

import { ChangeDetectorRef, Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { DomSanitizer } from '@angular/platform-browser';
import { PagingContactListComponent } from '../../paging-contact-list.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-matters',
  templateUrl: './matters.component.html',
})
export class ContactMattersComponent extends PagingContactListComponent {
  constructor(
    router: Router,
    changeDetectorRef: ChangeDetectorRef,
    contactService: ContactService,
    sanitizer: DomSanitizer,
  ) {
    super(router, changeDetectorRef, contactService, sanitizer);
  }
}

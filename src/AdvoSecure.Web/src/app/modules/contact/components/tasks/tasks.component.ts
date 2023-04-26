import { ChangeDetectorRef, Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { DomSanitizer } from '@angular/platform-browser';
import { PagingContactListComponent } from '../../paging-contact-list.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-tasks',
  templateUrl: './tasks.component.html',
})
export class ContactTasksComponent extends PagingContactListComponent {
  constructor(
    router: Router,
    changeDetectorRef: ChangeDetectorRef,
    contactService: ContactService,
    sanitizer: DomSanitizer,
  ) {
    super(router, changeDetectorRef, contactService, sanitizer);
  }
}

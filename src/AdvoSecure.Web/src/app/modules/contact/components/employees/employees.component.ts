import { ChangeDetectorRef, Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';
import { DomSanitizer } from '@angular/platform-browser';
import { PagingContactListComponent } from '../../paging-contact-list.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
})
export class EmployeesComponent extends PagingContactListComponent {
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
      .getEmployees(this.searchTerm)
      .subscribe((employees: Contact[]) => {
        this.POSTS = employees.map((employee) => {
          employee.avatar = employee.pictureBin
            ? this.sanitizer?.bypassSecurityTrustUrl(
                'data:image/jpeg;base64,' + employee.pictureBin
              )
            : './assets/media/avatars/blank.png';
          return employee;
        });
        this.changeDetectorRef.detectChanges();
      });
  }

  redirectToNewEmployee() {
    this.router.navigate(['/management/contacts/details'], {
      queryParams: { type: 'employee' },
    });
  }

  redirectToExistingEmployee(id: number) {
    this.router.navigate(['/management/contacts/details/' + id], {
      queryParams: { type: 'employee' },
    });
  }
}

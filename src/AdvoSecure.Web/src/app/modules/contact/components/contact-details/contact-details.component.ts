import { ChangeDetectorRef, Component, OnInit, NgModule } from '@angular/core';
import { BehaviorSubject, Subscription } from 'rxjs';
import { ContactService } from '../../services/contact.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Contact } from '../../models/contact.model';
import { ContactIdType } from '../../models/contact-id-type.model';
import { ContactMaritalStatus } from '../../models/contact-marital-status.model';
import { BillingRate } from 'src/app/models/billing-rate.model';
import { Country } from 'src/app/models/country.model';
import { CommonService } from 'src/app/services/common.service';
import { genders } from 'src/app/helpers/staticListHelper';
import { CompanyLegalStatus } from 'src/app/models/company-legal-status.model';

type Tabs = 'address-tab' | 'extra-tab' | 'financial-tab' | 'history-tab';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
})
export class ContactDetailsComponent implements OnInit {
  isLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoading: boolean;
  private unsubscribe: Subscription[] = [];

  activeTab: Tabs = 'address-tab';

  avatarFile: File;
  avatarSrc: string | SafeUrl = '/assets/media/avatars/blank.png';

  routeContactId: string | null;
  routeContactTypeParam: string | null;
  contactFormTitle: string = 'Contact details';

  sameAsPostalAddress: boolean;
  isChecked: false;

  contact: Contact = {
    id: 0,
    displayName: '',
  };

  idTypes: ContactIdType[] = [];
  maritalStatuses: ContactMaritalStatus[] = [];
  billingRates: BillingRate[] = [];
  companyLegalStatuses: CompanyLegalStatus[] = [];
  countries: Country[] = [];
  genders = genders;
  dateErrorMessage = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private changeDetectorRef: ChangeDetectorRef,
    private sanitizer: DomSanitizer,
    private commonService: CommonService,
    private contactService: ContactService
  ) {
    const loadingSubscr = this.isLoading$
      .asObservable()
      .subscribe((res) => (this.isLoading = res));
    this.unsubscribe.push(loadingSubscr);
  }

  ngOnInit(): void {
    this.routeContactTypeParam = this.route.snapshot.queryParamMap.get('type');
    if (this.routeContactTypeParam === 'employee') {
      this.contactFormTitle = 'Employee details';
    } else if (this.routeContactTypeParam === 'person') {
      this.contactFormTitle = 'Person details';
    } else if (this.routeContactTypeParam === 'company') {
      this.contactFormTitle = 'Company details';
    }

    this.routeContactId = this.route.snapshot.paramMap.get('id');
    if (this.routeContactId) {
      this.loadExistingContact(parseInt(this.routeContactId));
    } else {
      this.loadNewContact();
    }
    this.loadSelectList();
  }

  loadNewContact() {
    this.contact.isOrganization = this.routeContactTypeParam === 'company';
  }

  loadExistingContact(id: number) {
    this.contactService.getContact(id).subscribe((contact: Contact) => {
      this.contact = contact;

      if (this.contact.pictureBin) {
        this.avatarSrc = this.contact.avatar =
          this.sanitizer.bypassSecurityTrustUrl(
            'data:image/jpeg;base64,' + this.contact.pictureBin
          );
      }

      this.changeDetectorRef.detectChanges();
    });
  }

  loadSelectList() {
    this.contactService.getIdTypes().subscribe((result: ContactIdType[]) => {
      this.idTypes = result;
      this.changeDetectorRef.detectChanges();
    });

    this.contactService
      .getMaritalStatuses()
      .subscribe((result: ContactMaritalStatus[]) => {
        this.maritalStatuses = result;
        this.changeDetectorRef.detectChanges();
      });

    this.commonService.getBillingRates().subscribe((result: BillingRate[]) => {
      this.billingRates = result;
      this.changeDetectorRef.detectChanges();
    });

    this.commonService
      .getCompanyLegalStatuses()
      .subscribe((result: CompanyLegalStatus[]) => {
        this.companyLegalStatuses = result;
        this.changeDetectorRef.detectChanges();
      });

    this.commonService.getCountries().subscribe((result: Country[]) => {
      this.countries = result;
      this.changeDetectorRef.detectChanges();
    });
  }

  setTab(tab: Tabs) {
    this.activeTab = tab;
  }

  activeClass(tab: Tabs) {
    return tab === this.activeTab ? 'show active' : '';
  }

  updateAvatar(event: any): void {
    const files = event.target.files;
    if (files && files[0]) {
      const file = files[0];
      this.avatarFile = file;
      this.avatarSrc = this.sanitizer.bypassSecurityTrustUrl(
        window.URL.createObjectURL(file)
      );
    }
  }

  save = () => {
    try {
      if (this.avatarFile) {
        const reader = new FileReader();
        reader.readAsBinaryString(this.avatarFile);
        reader.onload = (event: any) => {
          this.saveContact(event.target.result);
        };
      } else {
        this.saveContact();
      }
    } catch (error) {
      console.log('save contact', error);
      this.isLoading = false;
      this.changeDetectorRef.detectChanges();
    }
  };

  saveContact(avatarBinaryString?: string) {
    if (avatarBinaryString) {
      this.contact.pictureBin = btoa(avatarBinaryString);
    }

    if (this.routeContactId) {
      this.contactService
        .updateContact(this.routeContactId, this.contact)
        .subscribe((savedContact: Contact) => {
          this.isLoading = false;
          this.changeDetectorRef.detectChanges();
          setTimeout(() => {
            this.redirectToListPage();
          }, 1000);
        });
    } else {
      this.contactService
        .createContact(this.contact)
        .subscribe((savedContact: Contact) => {
          this.isLoading = false;
          this.changeDetectorRef.detectChanges();
          setTimeout(() => {
            this.redirectToListPage();
          }, 1000);
        });
    }
  }

  updateInput() {
    this.contact.address2AddressStreet = this.contact.address1AddressStreet;
    this.contact.address2AddressLine2 = this.contact.address1AddressLine2;
    this.contact.address2AddressPostalCode =
      this.contact.address1AddressPostalCode;
    this.contact.address3AddressHouseNo = this.contact.address2AddressHouseNo;
    this.contact.address3AddressCity = this.contact.address2AddressCity;
    this.contact.address2AddressStateOrProvince =
      this.contact.address1AddressStateOrProvince;
    this.contact.address3AddressHouseNoExt =
      this.contact.address2AddressHouseNoExt;
    this.contact.address2AddressCountry = this.contact.address1AddressCountry;
  }

  isValidDateOfBirth(dateOfBirth: string): boolean {
    const date = new Date(dateOfBirth);

    if (isNaN(date.getTime())) {
      return false;
    }

    const now = new Date();
    const diff = now.getTime() - date.getTime();

    const age = diff / 1000 / 60 / 60 / 24 / 365.25;
    return age >= 18;
  }

  dateChange(event: any) {
    const dob = event.target?.value;
    if (this.isValidDateOfBirth(dob)) {
      this.dateErrorMessage = 'Valid date of birth';
    } else {
      this.dateErrorMessage = 'Invalid date of birth';
    }
  }

  redirectToListPage() {
    if (this.routeContactTypeParam === 'employee') {
      this.router.navigate(['/management/contacts/employees']);
    } else if (this.routeContactTypeParam === 'person') {
      this.router.navigate(['/management/contacts/persons']);
    } else if (this.routeContactTypeParam === 'company') {
      this.router.navigate(['/management/contacts/companies']);
    } else {
      this.router.navigate(['/management/contacts/all']);
    }
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}

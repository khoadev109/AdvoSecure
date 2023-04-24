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
import { FormGroup } from '@angular/forms';
import { genders } from 'src/app/helpers/staticListHelper';

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
  formGroup: FormGroup;

  enableSaveButtonFirstEdit: boolean = false;

  avatarImageFile: File;
  avatarSrc: string | SafeUrl = '/assets/media/avatars/blank.png';

  routeContactId: string | null;
  routeContactTypeParam: string | null;
  contactFormTitle: string = 'Contact details';

  sameAsPostalAddress: boolean;
  streetPostbox1: '';
  streetPostbox2: '';
  addressModel1: '';
  addressModel2: '';
  postCode1: '';
  postCode2: '';
  houseNumber1: '';
  houseNumber2: '';
  place1: '';
  place2: '';
  provinceState1: '';
  provinceState2: '';
  addition1: '';
  addition2: '';
  country1: '';
  country2: '';
  isChecked: false;

  contact: Contact = {
    id: 0,
    displayName: '',
    bankAccount: '',
    bicCode: '',
    bankName: '',
    sepaMandateNumber: '',
    sepaMandateDate: new Date(),
    sepaMandateLimit: 0,
    middleName: '',
    initials: '',
    onlineStatusId: 0,
    email1DisplayName: '',
    email1EmailAddress: '',
    email2DisplayName: '',
    email2EmailAddress: '',
    email3DisplayName: '',
    email3EmailAddress: '',
    fax1DisplayName: '',
    fax1FaxNumber: '',
    fax2DisplayName: '',
    fax2FaxNumber: '',
    fax3DisplayName: '',
    fax3FaxNumber: '',
    address1DisplayName: '',
    address1AddressStreet: '',
    address1AddressHouseNo: '',
    address1AddressHouseNoExt: '',
    address1AddressLine2: '',
    address1AddressCity: '',
    address1AddressPostalCode: '',
    address1AddressCountry: '',
    address1AddressCountryCode: '',
    address2AddressStreet: '',
    address2AddressCity: '',
    address2AddressHouseNoExt: '',
    address2AddressHouseNo: '',
    address2AddressLine2: '',
    address2AddressStateOrProvince: '',
    address2AddressPostalCode: '',
    address2AddressCountry: '',
    address2AddressCountryCode: '',
    address1AddressPostOfficeBox: '',
    address2DisplayName: '',
    address2AddressPostOfficeBox: '',
    address3DisplayName: '',
    address3AddressStreet: '',
    address3AddressHouseNo: '',
    address3AddressHouseNoExt: '',
    address3AddressLine2: '',
    address3AddressCity: '',
    address3AddressStateOrProvince: '',
    address3AddressPostalCode: '',
    address3AddressCountry: '',
    address3AddressCountryCode: '',
    address3AddressPostOfficeBox: '',
    telephone3DisplayName: '',
    telephone3TelephoneNumber: '',
    telephone4DisplayName: '',
    telephone4TelephoneNumber: '',
    telephone5DisplayName: '',
    telephone5TelephoneNumber: '',
    telephone6DisplayName: '',
    telephone6TelephoneNumber: '',
    telephone7DisplayName: '',
    telephone7TelephoneNumber: '',
    telephone8DisplayName: '',
    telephone8TelephoneNumber: '',
    telephone9DisplayName: '',
    telephone10DisplayName: '',
    telephone10TelephoneNumber: '',
    departmentName: '',
    officeLocation: '',
    managerName: '',
    assistantName: '',
    instantMessagingAddress: '',
    personalHomePage: '',
    businessHomePage: '',
    socialSecurityNumber: '',
  };

  idTypes: ContactIdType[] = [];
  maritalStatuses: ContactMaritalStatus[] = [];
  billingRates: BillingRate[] = [];
  countries: Country[] = [];
  genders = genders;
  date = '';

  // activeTab: Tabs = 'address-tab';
  selectedIdTypeId: number | undefined = 0;
  selectedMaritalStatusId: number | undefined = 0;
  selectedCountryId: string | undefined = '';
  selectedCountryVaId: string | undefined = '';
  selectedGender: string | undefined = '';
  selectedCountryId1: string | undefined = '';
  selectedCountryId2: string | undefined = '';

  dateOfBirth: Date = new Date();
  today: Date = new Date();
  maxDate =
    new Date().getFullYear().toString() +
    '-0' +
    (new Date().getMonth() + 1).toString() +
    '-' +
    new Date().getDate().toString();

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
    this.routeContactId = this.route.snapshot.paramMap.get('id');
    if (this.routeContactId) {
      this.loadContact(parseInt(this.routeContactId));
    }

    this.routeContactTypeParam = this.route.snapshot.queryParamMap.get('type');
    if (this.routeContactTypeParam === 'employee') {
      this.contactFormTitle = 'Employee details';
    } else if (this.routeContactTypeParam === 'person') {
      this.contactFormTitle = 'Person details';
    }

    this.loadSelectList();
  }

  loadContact(id: number) {
    this.contactService.getContact(id).subscribe((contact: Contact) => {
      this.contact = contact;

      if (this.contact.pictureBin) {
        this.avatarSrc = this.contact.avatar =
          this.sanitizer.bypassSecurityTrustUrl(
            'data:image/jpeg;base64,' + this.contact.pictureBin
          );
      }

      this.enableSaveButtonFirstEdit = true;
      this.selectedIdTypeId = this.contact.idTypeId;
      this.selectedMaritalStatusId = this.contact.civilStatusId;
      this.selectedGender = this.contact.gender;

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
      this.avatarImageFile = file;
      this.avatarSrc = this.sanitizer.bypassSecurityTrustUrl(
        window.URL.createObjectURL(file)
      );
    }
  }

  save = () => {
    try {
      var reader = new FileReader();
      reader.onload = (event: any) => {
        var binaryString = event.target.result;
        this.contact.pictureBin = btoa(binaryString);
        this.contact.idTypeId = this.selectedIdTypeId;
        this.contact.civilStatusId = this.selectedMaritalStatusId;
        this.contact.gender = this.selectedGender;

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
      };

      reader.readAsBinaryString(this.avatarImageFile);
    } catch (error) {
      console.log('save contact', error);
      this.isLoading = false;
      this.changeDetectorRef.detectChanges();
    }
  };

  updateInput() {
    if (this.isChecked) {
      this.streetPostbox2 = this.streetPostbox1;
      this.addressModel2 = this.addressModel1;
      this.postCode2 = this.postCode1;
      this.houseNumber2 = this.houseNumber1;
      this.place2 = this.place1;
      this.provinceState2 = this.provinceState1;
      this.addition2 = this.addition1;
      this.selectedCountryId2 = this.selectedCountryId1;
    } else {
      this.streetPostbox2 = '';
      this.addressModel2 = '';
      this.postCode2 = '';
      this.houseNumber2 = '';
      this.place2 = '';
      this.provinceState2 = '';
      this.addition2 = '';
      this.selectedCountryId2 = '';
    }
  }

  goToAll() {
    this.router.navigate(['/management/contacts/all']);
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
      this.date = 'Valid date of birth';
    } else {
      this.date = 'Invalid date of birth';
    }
  }
  redirectToListPage() {
    if (this.routeContactTypeParam === 'employee') {
      this.router.navigate(['/management/contacts/employees']);
    } else if (this.routeContactTypeParam === 'person') {
      this.router.navigate(['/management/contacts/persons']);
    } else {
      this.router.navigate(['/management/contacts/all']);
    }
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}

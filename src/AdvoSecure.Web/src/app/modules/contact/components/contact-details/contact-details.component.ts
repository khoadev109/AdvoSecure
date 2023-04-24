import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
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

  contact: Contact = {
    id: 0,
    displayName: '',
  };

  idTypes: ContactIdType[] = [];
  maritalStatuses: ContactMaritalStatus[] = [];
  billingRates: BillingRate[] = [];
  countries: Country[] = [];
  genders = genders;

  selectedIdTypeId: number | undefined = 0;
  selectedMaritalStatusId: number | undefined = 0;
  selectedCountryId: string | undefined = '';
  selectedCountryVaId: string | undefined = '';
  selectedGender: string | undefined = '';

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

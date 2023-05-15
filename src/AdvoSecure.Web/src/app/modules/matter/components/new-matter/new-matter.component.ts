import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Subscription } from 'rxjs';
import { MatterService } from '../../services/matter.service';
import { MatterType } from '../../models/matter-type.model';
import { MatterArea } from '../../models/matter-area.model';
import { CourtSittingInCity } from '../../models/court-sitting-city.model';
import { CourtGeoJurisdiction } from '../../models/court-geo-jurisdiction.model';
import { Matter, defaultMatter } from '../../models/matter.model';
import { ContactService } from 'src/app/modules/contact/services/contact.service';
import { Contact } from 'src/app/modules/contact/models/contact.model';
import { CommonService } from 'src/app/services/common.service';
import { BillingRate } from 'src/app/models/billing-rate.model';
import { BillingGroup } from 'src/app/models/billing-group.model';
import { MatterContact } from '../../models/matter-contact.model';

@Component({
  selector: 'app-new-matter',
  templateUrl: './new-matter.component.html',
})
export class NewMatterComponent implements OnInit {
  isLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoading: boolean;
  private unsubscribe: Subscription[] = [];

  matter: Matter = defaultMatter;

  matterTypes: MatterType[] = [];
  matterAreas: MatterArea[] = [];
  courtSittingInCities: CourtSittingInCity[] = [];
  courtGeoJurisdictions: CourtGeoJurisdiction[] = [];
  contacts: Contact[] = [];
  billingRates: BillingRate[] = [];
  billingGroups: BillingGroup[] = [];

  constructor(
    private router: Router,
    private changeDetectorRef: ChangeDetectorRef,
    private matterService: MatterService,
    private contactService: ContactService,
    private commonService: CommonService
  ) {
    const loadingSubscr = this.isLoading$
      .asObservable()
      .subscribe((res) => (this.isLoading = res));
    this.unsubscribe.push(loadingSubscr);
  }

  ngOnInit(): void {
    this.loadSelectList();
  }

  loadSelectList() {
    this.matterService.getTypes().subscribe((result: MatterType[]) => {
      this.matterTypes = result;
      this.changeDetectorRef.detectChanges();
    });

    this.matterService.getAreas().subscribe((result: MatterArea[]) => {
      this.matterAreas = result;
      this.changeDetectorRef.detectChanges();
    });

    this.matterService
      .getCourtSittingInCities()
      .subscribe((result: CourtSittingInCity[]) => {
        this.courtSittingInCities = result;
        this.changeDetectorRef.detectChanges();
      });

    this.matterService
      .getCourtGeoJurisdictions()
      .subscribe((result: CourtGeoJurisdiction[]) => {
        this.courtGeoJurisdictions = result;
        this.changeDetectorRef.detectChanges();
      });

    this.contactService.getContacts().subscribe((result: Contact[]) => {
      this.contacts = result;
      this.changeDetectorRef.detectChanges();
    });

    this.commonService.getBillingRates().subscribe((result: BillingRate[]) => {
      this.billingRates = result;
      this.changeDetectorRef.detectChanges();
    });

    this.commonService
      .getBillingGroups()
      .subscribe((result: BillingGroup[]) => {
        this.billingGroups = result;
        this.changeDetectorRef.detectChanges();
      });
  }

  save() {
    this.matterService
      .createMatter(this.matter)
      .subscribe((savedMatter: Matter) => {
        this.isLoading = false;
        this.changeDetectorRef.detectChanges();
        setTimeout(() => {
          this.redirectToListPage();
        }, 1000);
      });
  }

  addSelectedContacts(matterContact: MatterContact) {
    this.matter.matterContacts?.push(matterContact);
  }

  redirectToListPage() {
    this.router.navigate(['/management/matters/search']);
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}

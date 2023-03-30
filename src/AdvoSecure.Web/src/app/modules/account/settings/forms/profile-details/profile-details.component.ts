import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { BehaviorSubject, Subscription } from 'rxjs';
import { Profile } from 'src/app/modules/msal/models/profile.model';
import { GraphService } from 'src/app/modules/msal/services/graph.service';

@Component({
  selector: 'app-profile-details',
  templateUrl: './profile-details.component.html',
})
export class ProfileDetailsComponent implements OnInit {
  isLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoading: boolean;
  private unsubscribe: Subscription[] = [];

  public profile: Profile = {
    givenName: '',
    surname: '',
    userPrincipalName: '',
    id: '',
  };

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private graphService: GraphService
  ) {
    const loadingSubscr = this.isLoading$
      .asObservable()
      .subscribe((res) => (this.isLoading = res));
    this.unsubscribe.push(loadingSubscr);
  }

  ngOnInit(): void {
    this.getProfile();
  }

  saveSettings() {
    this.isLoading$.next(true);
    this.graphService.updateProfile(this.profile).subscribe((response) => {
      setTimeout(() => {
        this.isLoading$.next(false);
        this.changeDetectorRef.detectChanges();
      }, 1500);
    });
  }

  getProfile() {
    this.graphService.getProfile().subscribe((profile: Profile) => {
      this.profile = profile;
      this.changeDetectorRef.markForCheck();
    });
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}

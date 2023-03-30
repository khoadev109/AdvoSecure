import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { GraphService } from 'src/app/modules/msal/services/graph.service';
import { Profile } from '../../msal/models/profile.model';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
})
export class OverviewComponent implements OnInit {
  profile: Profile = {
    givenName: '',
    surname: '',
    userPrincipalName: '',
    id: '',
  };

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private graphService: GraphService
  ) {}

  ngOnInit(): void {
    this.getProfile();
  }

  getProfile() {
    this.graphService.getProfile().subscribe((profile : Profile) => {
      this.profile = profile;
      this.changeDetectorRef.markForCheck();
    });
  }
}

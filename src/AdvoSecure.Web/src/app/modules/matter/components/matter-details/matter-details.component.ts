import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatterService } from '../../services/matter.service';
import { Matter, defaultMatter } from '../../models/matter.model';
import { ContactService } from 'src/app/modules/contact/services/contact.service';
import { CommonService } from 'src/app/services/common.service';
import { Opportunity } from '../../models/opportunity.model';

type Tabs =
  | 'task-activity-tab'
  | 'note-tab'
  | 'work-note-tab'
  | 'piece-document-tab'
  | 'history-tab';

@Component({
  selector: 'app-matter-details',
  templateUrl: './matter-details.component.html',
})
export class MatterDetailsComponent implements OnInit {
  activeTab: Tabs = 'task-activity-tab';

  routeMatterId: string;
  matter: Matter = defaultMatter;
  opportunities: Opportunity[] = [];
  opportunity: Opportunity = { id: 0 };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private changeDetectorRef: ChangeDetectorRef,
    private matterService: MatterService,
    private contactService: ContactService,
    private commonService: CommonService
  ) {}

  setTab(tab: Tabs) {
    this.activeTab = tab;
  }

  activeClass(tab: Tabs) {
    return tab === this.activeTab ? 'show active' : '';
  }

  ngOnInit(): void {
    this.routeMatterId = this.route.snapshot.paramMap.get('id') || '';
    this.loadDetails();
    this.loadMatterOpportunities();
  }

  loadDetails() {
    this.matterService
      .getDetails(this.routeMatterId)
      .subscribe((matter: Matter) => {
        this.matter = matter;
        this.changeDetectorRef.detectChanges();
      });
  }

  loadMatterOpportunities() {
    this.matterService.getOpportunities(this.routeMatterId).subscribe((res) => {
      this.opportunities = res;
      this.opportunity = this.opportunities[0];
      this.changeDetectorRef.detectChanges();
    });
  }
  redirectToListPage() {
    this.router.navigate(['/management/matters/search']);
  }
}

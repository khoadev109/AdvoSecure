import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatterService } from '../../services/matter.service';
import { Matter, defaultMatter } from '../../models/matter.model';
import { ContactService } from 'src/app/modules/contact/services/contact.service';
import { CommonService } from 'src/app/services/common.service';

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
  }

  loadDetails() {
    this.matterService
      .getDetails(this.routeMatterId)
      .subscribe((matter: Matter) => {
        this.matter = matter;
        this.changeDetectorRef.detectChanges();
      });
  }

  redirectToListPage() {
    this.router.navigate(['/management/matters/search']);
  }
}

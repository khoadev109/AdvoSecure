import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatterService } from '../../services/matter.service';

@Component({
  selector: 'app-matter-tasks',
  templateUrl: './matter-tasks.component.html',
})
export class MatterTasksComponent implements OnInit {
  public POSTS: any[];
  public page: number = 1;
  public count: number = 0;
  public tableSize: number = 7;
  public tableSizes: any = [3, 6, 9, 12];

  routeMatterId: string;

  constructor(
    public router: Router,
    private route: ActivatedRoute,
    public changeDetectorRef: ChangeDetectorRef,
    public matterService: MatterService
  ) {}

  ngOnInit(): void {
    this.routeMatterId = this.route.snapshot.paramMap.get('id') || '';

    this.fetchData();
  }

  fetchData() {
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.fetchData();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchData();
  }
}

import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatterService } from '../../services/matter.service';
import { Note } from '../../models/note.model';

@Component({
  selector: 'app-matter-notes',
  templateUrl: './matter-notes.component.html',
})
export class MatterNotesComponent implements OnInit {
  public POSTS: Note[];
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
    this.matterService
      .getMatterNotes(this.routeMatterId)
      .subscribe((notes: Note[]) => {
        this.POSTS = notes;
        this.changeDetectorRef.detectChanges();
      });
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

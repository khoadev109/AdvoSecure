import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatterService } from '../../services/matter.service';
import { Matter } from '../../models/matter.model';
import { MatterArea } from '../../models/matter-area.model';
import { CourtGeoJurisdiction } from '../../models/court-geo-jurisdiction.model';
import { SearchMatter } from '../../models/search-matter.model';

@Component({
  selector: 'app-matters',
  templateUrl: './matters.component.html',
})
export class MattersComponent implements OnInit {
  public POSTS: Matter[];
  public page: number = 1;
  public count: number = 0;
  public tableSize: number = 7;
  public tableSizes: any = [3, 6, 9, 12];

  matterAreas: MatterArea[] = [];
  courtGeoJds: CourtGeoJurisdiction[] = [];

  searchRequest: SearchMatter = {
    status: '',
    matterAreaId: 0,
    courtGeoJurisdictionId: 0,
  };

  constructor(
    public router: Router,
    public changeDetectorRef: ChangeDetectorRef,
    public matterService: MatterService
  ) {}

  ngOnInit(): void {
    this.loadSelectList();
    this.search();
  }

  search() {
    this.matterService
      .searchMatters(this.searchRequest)
      .subscribe((matters: Matter[]) => {
        this.POSTS = matters;
        this.changeDetectorRef.detectChanges();
      });
  }

  loadSelectList() {
    this.matterService.getAreas().subscribe((result: MatterArea[]) => {
      this.matterAreas = result;
      this.changeDetectorRef.detectChanges();
    });

    this.matterService
      .getCourtGeoJurisdictions()
      .subscribe((result: CourtGeoJurisdiction[]) => {
        this.courtGeoJds = result;
        this.changeDetectorRef.detectChanges();
      });
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.search();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.search();
  }
}

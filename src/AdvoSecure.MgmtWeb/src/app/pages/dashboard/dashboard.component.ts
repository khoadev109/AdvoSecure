import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  constructor(
    private changeDetectorRef: ChangeDetectorRef) {}

  ngOnInit(): void {
  }
}

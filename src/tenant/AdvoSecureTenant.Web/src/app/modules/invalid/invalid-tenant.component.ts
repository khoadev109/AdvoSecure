import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-invalid-tenant',
  templateUrl: './invalid-tenant.component.html',
  styleUrls: ['./invalid-tenant.component.scss'],
})
export class InvalidTenantComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {
    localStorage.clear();
  }
}

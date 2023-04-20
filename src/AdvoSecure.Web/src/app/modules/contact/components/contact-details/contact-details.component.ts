import { Component, OnInit } from '@angular/core';

type Tabs =
  | 'address-tab'
  | 'extra-tab'
  | 'financial-tab'
  | 'history-tab';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
})
export class ContactDetailsComponent implements OnInit {
  activeTab: Tabs = 'address-tab';

  setTab(tab: Tabs) {
    this.activeTab = tab;
  }

  activeClass(tab: Tabs) {
    return tab === this.activeTab ? 'show active' : '';
  }

  ngOnInit(): void {
  }
}

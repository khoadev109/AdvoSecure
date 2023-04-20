import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { BehaviorSubject, Subscription } from 'rxjs';
import * as fs from 'fs';
import { ContactUploadImage } from '../../models/contact-upload-image.model';

type Tabs = 'address-tab' | 'extra-tab' | 'financial-tab' | 'history-tab';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
})
export class ContactDetailsComponent implements OnInit {
  isLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoading: boolean;
  activeTab: Tabs = 'address-tab';
  selectedFile: File | null = null;
  private unsubscribe: Subscription[] = [];

  constructor(private contactService: ContactService) {
    const loadingSubscr = this.isLoading$
      .asObservable()
      .subscribe((res) => (this.isLoading = res));
    this.unsubscribe.push(loadingSubscr);
  }

  setTab(tab: Tabs) {
    this.activeTab = tab;
  }

  activeClass(tab: Tabs) {
    return tab === this.activeTab ? 'show active' : '';
  }

  ngOnInit(): void {}

  onUploadImage() {
    console.log('123');
    if (this.selectedFile !== null) {
      const formData = new FormData();
      formData.append('file', this.selectedFile, this.selectedFile.name);
      console.log('first', this.selectedFile);
      this.contactService.updateImage(formData).subscribe(
        (res) => {
          console.log('res', res);
        },
        (error) => {
          console.log('error', error);
        }
      );
    }
  }

  onFileSelected(event: any) {
    console.log('event', event);
    console.log('event 2', event.target.files[0]);
    this.selectedFile = <File>event.target.files[0];
  }
}

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Contact } from 'src/app/modules/contact/models/contact.model';
import {
  MatterContact,
  defaultMatterContact,
} from '../../models/matter-contact.model';

@Component({
  selector: 'app-matter-contact',
  templateUrl: './matter-contact.component.html',
})
export class MatterContactComponent implements OnInit {
  @Input() contactNumber: number;
  @Input() contacts: Contact[];
  @Output() selectContactEvent = new EventEmitter<MatterContact>();

  listId: string;
  contactPlaceholder: string;

  matterContact: any = { ...defaultMatterContact };

  ngOnInit(): void {
    this.listId = `contact-list_${this.contactNumber}`;
  }

  search(event: any) {
    const value = event.target.value || '';
    const contact = this.contacts.find(
      (x) => x?.displayName.toLowerCase() === value.toLowerCase()
    );
    this.matterContact.contactId = contact?.id || 0;
    this.selectContactEvent.emit(this.matterContact);
  }

  selectRole(roleName: string) {
    this.matterContact[roleName] = !this.matterContact[roleName];
    this.selectContactEvent.emit(this.matterContact);
  }
}

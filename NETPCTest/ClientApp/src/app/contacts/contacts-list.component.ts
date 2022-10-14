import { Component, Inject } from '@angular/core';
import { Contact } from './contact';
import { ContactService } from './contact.service';
@Component({
  selector: 'contacts-list',
  templateUrl: './contacts-list.component.html'
})
export class ContactListComponent {
  pageTitle = 'Contact List';
  errorMessage = '';

  _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredContacts = this.listFilter
      ? this.performFilter(this.listFilter) : this.Contacts;
  }

  filteredContacts: Contact[] = [];
  Contacts: Contact[] = [];

  constructor(private ContactService: ContactService) { }

  performFilter(filterBy: string): Contact[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.Contacts.filter((Contact: Contact) =>
      Contact.lastName.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  ngOnInit(): void {
    this.ContactService.getContacts().subscribe({
      next: Contacts => {
        this.Contacts = Contacts;
        this.filteredContacts = this.Contacts;
      },
      error: err => this.errorMessage = err
    });
  }
}

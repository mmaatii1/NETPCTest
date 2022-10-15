import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChildren } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { debounceTime, fromEvent, merge, Observable, Subscription } from 'rxjs';
import { GenericValidator } from '../../generic-validator';
import { Contact } from '../contact';
import { ContactService } from '../contact.service';
@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrls: ['./contact-edit.component.css']
})
export class ContactEditComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  pageTitle = 'Contact Edit';
  errorMessage: string;
  contactForm: FormGroup;
  id: number;
  contact: Contact;
  private sub: Subscription;

  // Use with the generic validation message class
  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  get tags(): FormArray {
    return this.contactForm.get('tags') as FormArray;
  }

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private router: Router,
              private ContactService: ContactService) {

    // Defines all of the validation messages for the form.
    // These could instead be retrieved from a file or database.
    this.validationMessages = {
      ContactName: {
        required: 'Contact name is required.',
        minlength: 'Contact name must be at least three characters.',
        maxlength: 'Contact name cannot exceed 50 characters.'
      },
      ContactCode: {
        required: 'Contact code is required.'
      },
      starRating: {
        range: 'Rate the Contact between 1 (lowest) and 5 (highest).'
      }
    };

    // Define an instance of the validator for use with this form,
    // passing in this form's set of validation messages.
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit(): void {
    this.contactForm = this.fb.group({
      ContactName: ['', [Validators.required,
                         Validators.minLength(3),
                         Validators.maxLength(50)]],
      ContactCode: ['', Validators.required],
      tags: this.fb.array([]),
      description: ''
    });

   
    // Read the Contact Id from the route parameter
   
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngAfterViewInit(): void {
    // Watch for the blur event from any input element on the form.
    // This is required because the valueChanges does not provide notification on blur
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    // Merge the blur event observable with the valueChanges observable
    // so we only need to subscribe once.
    merge(this.contactForm.valueChanges, ...controlBlurs).pipe(
      debounceTime(800)
    ).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.contactForm);
    });
  }

  addTag(): void {
    this.tags.push(new FormControl());
  }

  deleteTag(index: number): void {
    this.tags.removeAt(index);
    this.tags.markAsDirty();
  }

  getContact(id: number): void {
    this.ContactService.getContact(id)
      .subscribe({
        next: (Contact: Contact) => this.displayContact(Contact),
        error: err => this.errorMessage = err
      });
  }

  displayContact(Contact: Contact): void {
    if (this.contactForm) {
      this.contactForm.reset();
    }
    this.contact = Contact;

    if (this.contact.id === 0) {
      this.pageTitle = 'Add Contact';
    } else {
      this.pageTitle = `Edit Contact: ${this.contact.lastName}`;
    }

    // Update the data on the form
    this.contactForm.patchValue({
      ContactName: this.contact.lastName,
      ContactCode: this.contact.firstName,
      description: this.contact.dateOfBirth
    });
  }

  deleteContact(): void {
    if (this.contact.id === 0) {
      // Don't delete, it was never saved.
      this.onSaveComplete();
    } else {
      if (confirm(`Really delete the Contact: ${this.contact.lastName}?`)) {
        this.ContactService.deleteContact(this.contact.id)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }

  saveContact(): void {
    if (this.contactForm.valid) {
      if (this.contactForm.dirty) {
        const p = { ...this.contact, ...this.contactForm.value };

        if (p.id === 0) {
          this.ContactService.createContact(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        } else {
          this.ContactService.updateContact(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.contactForm.reset();
    this.router.navigate(['/Contacts']);
  }
}

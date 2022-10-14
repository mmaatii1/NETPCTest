import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap, throwError } from 'rxjs';
import { Contact } from './contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private ContactsUrl = 'https://localhost:7061/api/Contact';

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.ContactsUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getContact(id: number): Observable<Contact> {
    if (id === 0) {
      return of(this.initializeContact());
    }
    const url = `${this.ContactsUrl}/${id}`;
    return this.http.get<Contact>(url)
      .pipe(
        catchError(this.handleError)
      );
  }

  createContact(Contact: Contact): Observable<Contact> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Contact>(this.ContactsUrl, Contact, { headers })
      .pipe(
        tap(data => console.log('createContact: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteContact(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.ContactsUrl}/${id}`;
    return this.http.delete<Contact>(url, { headers })
      .pipe(
        tap(data => console.log('deleteContact: ' + id)),
        catchError(this.handleError)
      );
  }

  updateContact(Contact: Contact): Observable<Contact> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.ContactsUrl}/${Contact.id}`;
    return this.http.put<Contact>(url, Contact, { headers })
      .pipe(
        tap(() => console.log('updateContact: ' + Contact.id)),
        // Return the Contact on an update
        map(() => Contact),
        catchError(this.handleError)
      );
  }

  private handleError(err: any) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

  private initializeContact(): Contact {
    // Return an initialized object
    return {
      id: 0,
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      categoryId: 0,
      subCategoryId: 0,
      categoryName: '',
      subCategoryName: '',
      phoneNumber: 0,
      dateOfBirth: new Date(),
    };
  }
}

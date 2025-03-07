import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private apiUrl = 'http://localhost:8000/Contact/SendMessage';

  constructor(private http: HttpClient) {}

  sendMessage(formData: any): Observable<any> {
    return this.http.post(this.apiUrl, formData);
  }

  getMessages(): Observable<any[]> {
    return this.http.get<any[]>('http://localhost:8000/Contact/Get');
  }

}

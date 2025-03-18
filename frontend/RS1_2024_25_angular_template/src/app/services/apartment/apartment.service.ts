import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Apartment } from '../../models/apartment.model';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService {
  private apiUrl = 'http://localhost:8000/apartment';

  constructor(private http: HttpClient) {}

  // preuzimanje svih apartmana
  getApartments(): Observable<Apartment[]> {
    return this.http.get<Apartment[]>(`${this.apiUrl}/Get`);
  }

  // preuzimanje apartmana po ID-u
  getApartmentById(id: number): Observable<Apartment> {
    return this.http.get<Apartment>(`${this.apiUrl}/GetById/${id}`);
  }

  // brisanje
  deleteApartment(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/Delete/${id}`);
  }

  // dodavanje
  addApartment(apartment: Apartment): Observable<Apartment> {
    return this.http.post<Apartment>(`${this.apiUrl}/Insert`, apartment);
  }

  // update
  updateApartment(apartment: Apartment): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/Update`, apartment);
  }
}

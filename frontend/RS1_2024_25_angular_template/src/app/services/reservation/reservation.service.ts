import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Reservation } from '../../models/reservation.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private apiUrl = 'http://localhost:8000/Reservation';

  constructor(private http: HttpClient) { }

  getReservationById(id: number): Observable<Reservation> {
    return this.http.get<Reservation>(`${this.apiUrl}/GetById/${id}`);
  }

  createReservation(reservation: Reservation): Observable<Reservation> {
    return this.http.post<Reservation>(`${this.apiUrl}/Insert`, reservation);
  }

  cancelReservation(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/Cancel/${id}`);
  }

  getOccupiedDates(apartmentId: number): Observable<{ startDate: Date, endDate: Date }[]> {
    return this.http.get<{ startDate: string, endDate: string }[]>(`${this.apiUrl}/GetOccupiedDates/GetOccupiedDates/${apartmentId}`).pipe(
      map(dates => {
        return dates.map(date => {
          return {
            startDate: new Date(date.startDate),  // Konvertuj startDate u Date objekat
            endDate: new Date(date.endDate)       // Konvertuj endDate u Date objekat
          };
        });
      })
    );
  }




}


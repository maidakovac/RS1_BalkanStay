import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReservationService } from '../../services/reservation/reservation.service';
import { Reservation } from '../../models/reservation.model';
import {SharedModule} from '../shared/shared.module';

@Component({
  selector: 'app-reservation-form',
  templateUrl: './reservation-form.component.html',
  imports: [
    SharedModule
  ],
  styleUrls: ['./reservation-form.component.css']
})
export class ReservationFormComponent {
  @Input() apartmentId!: number;
  reservationForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private reservationService: ReservationService
  ) {
    this.reservationForm = this.fb.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });
  }

  submitReservation() {
    if (this.reservationForm.valid) {
      const reservation: Reservation = {
        reservationID: 0,
        accountID: 1, // Postaviti na ID prijavljenog korisnika
        apartmentId: this.apartmentId,
        startDate: this.reservationForm.value.startDate,
        endDate: this.reservationForm.value.endDate,
        status: true
      };

      this.reservationService.createReservation(reservation).subscribe(() => {

        alert('Reserved!');
      });

    }
  }
}

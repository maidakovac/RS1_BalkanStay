import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReservationService } from '../../services/reservation/reservation.service';
import { Reservation } from '../../models/reservation.model';
import { DatepickerDateCustomClasses } from 'ngx-bootstrap/datepicker';


@Component({
  selector: 'app-reservation-form',
  templateUrl: './reservation-form.component.html',
  standalone: false,
  styleUrls: ['./reservation-form.component.css']
})
export class ReservationFormComponent implements OnInit {
  @Input() apartmentId!: number;
  reservationForm: FormGroup;
  occupiedDates: Date[] = [];
  minDate: Date = new Date();
  todayClass: DatepickerDateCustomClasses[] = [];
  maxCheckOutDate: Date | undefined = undefined;
  minCheckOutDate: Date | undefined = undefined;

  constructor(
    private fb: FormBuilder,
    private reservationService: ReservationService
  ) {
    this.reservationForm = this.fb.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });
  }

  ngOnInit() {

    this.setTodayClass();
    if (this.apartmentId) {
      this.loadOccupiedDates();
    }
  }

  setTodayClass() {

  }

  loadOccupiedDates() {
    this.reservationService.getOccupiedDates(this.apartmentId).subscribe(dates => {
      let blockedDates: Date[] = [];

      dates.forEach(d => {
        let start = new Date(d.startDate);
        let end = new Date(d.endDate);
        let currentDate = new Date(start);

        while (currentDate <= end) {
          blockedDates.push(new Date(currentDate));
          currentDate.setDate(currentDate.getDate() + 1);
        }
      });

      this.occupiedDates = blockedDates;
    });
  }
  onStartDateChange(selectedDate: Date) {
    if (!selectedDate) return;
    this.minCheckOutDate = selectedDate;

    this.reservationForm.controls['endDate'].setValue(null)


    this.maxCheckOutDate = this.occupiedDates
      .filter(d => d > selectedDate)
      .sort((a, b) => a.getTime() - b.getTime())[0] || null;
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

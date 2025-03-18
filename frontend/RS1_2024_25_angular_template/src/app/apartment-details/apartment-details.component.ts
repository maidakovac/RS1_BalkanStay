import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../services/apartment.service';
import { Apartment } from '../models/apartment.model';

@Component({
  selector: 'app-apartment-details',
  templateUrl: './apartment-details.component.html',
  standalone: false,
  styleUrls: ['./apartment-details.component.css']
})
export class ApartmentDetailsComponent implements OnInit {
  apartmentId: number = 0;
  apartment: Apartment | null = null;
  loading: boolean = false;
  errorMessage: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private apartmentService: ApartmentService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id && !isNaN(+id)) {
        this.apartmentId = +id;
        this.getApartmentDetails();
      } else {
        console.error('Invalid apartment ID');
        this.errorMessage = 'Invalid apartment ID';
      }
    });
  }

  getApartmentDetails() {
    this.loading = true;
    this.apartmentService.getApartmentById(this.apartmentId).subscribe(
      (response) => {
        console.log('Fetched Apartment Data:', response);
        this.apartment = response;
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching apartment details', error);
        this.errorMessage = 'Sorry, the apartment details could not be loaded.';
        this.loading = false;
      }
    );
  }

}

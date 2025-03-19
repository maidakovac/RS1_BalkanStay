import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../../../services/apartment/apartment.service';
import { Apartment } from '../../../models/apartment.model';

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
  selectedImage: string = '';

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

  selectImage(imagePath: string) {
    this.selectedImage = imagePath;
  }

  getApartmentDetails() {
    this.loading = true;
    this.apartmentService.getApartmentById(this.apartmentId).subscribe(
      (response) => {
        this.apartment = response;
        this.loading = false;
        console.log("Apartment data loaded:", this.apartment);

        // Postavljanje prve slike kao glavne kada podaci stignu
        if (this.apartment?.imagePaths?.length > 0) {
          this.selectedImage = this.apartment.imagePaths[0];
          console.log("Main image selected:", this.selectedImage);
        } else {
          console.warn("No images found for this apartment");
        }
      },
      (error) => {
        console.error('Error fetching apartment details', error);
        this.errorMessage = 'Sorry, the apartment details could not be loaded.';
        this.loading = false;
      }
    );
  }
}

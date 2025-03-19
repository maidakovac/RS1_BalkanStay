import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {timer} from 'rxjs';
import { Router } from '@angular/router';
import { Apartment, ApartmentImage, Reservation, Account, ApartmentRule, ApartmentAmenity, ApartmentToiletry} from '../../../models/apartment.model';

export interface GetPodaciResponse {
  datumPonude: string
  podaci: Drzava[]
}

export interface Drzava {
  id: number
  drzava: string
  boravakGradovi: BoravakGradovi[]
  slikaUrl: string
  opisPonude: string
  akcijaPoruka: string
  naredniPolazak: NaredniPolazak
  planiranaPutovanja: PlaniranaPutovanja[]
}

//export interface Apartment {
//  apartmentId: number;
//  name: string;
//  description: string;
//  adress: string;
//  pricePerNight: number;
//  cityId: number | null;
//  accountID: number | null;
//  apartmentImages: ApartmentImages[];
//  city: City;
//}

export interface City {
  id: number;
  name: string;
  countryId: number;
  country: Country;
}

export interface Country {
  id: number;
  name: string;
  cities: City[]
}

export interface ApartmentImages {
  apartmentImageID: number;
  apartmentId: number;
  imageID: number;
  image: Image;
}

export interface Image {
  imageID: number
  imagePath: string
}

export interface BoravakGradovi {
  brojNocenja: number
  hotelNaziv: string
  nazivGrada: string
}

export interface NaredniPolazak {
  zaDana: number
  datumPol: string
  countSlobodnoMjesta: number
  cijenaPoOsobiEur: number
}

export interface PlaniranaPutovanja {
  idPutovanje: number
  countSlobodnoMjesta: number
  cijenaPoOsobiEur: number
  datumPol: string
  datumPov: string
  brojDana: number
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  standalone: false
})
export class HomeComponent implements OnInit, AfterViewInit {

  @ViewChild('scrollAnchor', { static: false }) scrollAnchor!: ElementRef;

  traziVrijednost: string = "";
  bazniUrl: string = "http://localhost:8000";
  globalPodaci: Drzava[] = [];
  sviApartmani: Apartment[] = [];
  odabranaDrzava: Drzava | null = null;
  odabranoPutovanje: PlaniranaPutovanja | null = null;

  odabraniApartman: Apartment | null = null;


  checkInDate: Date | null = null;
  checkOutDate: Date | null = null;
  sviGradovi: City[] = [];
  filteredCities: City[] = [];
  showDropdown: boolean = false;

  page: number = 1;
  isLoading: boolean = false;
  isFiltered: boolean = false;
  hasMoreData: boolean = true;
  pageSize: number = 12;
  totalApartments: number = 0;
  filtriraniApartmani: Apartment[] = [];

  private firstLoadDone: boolean = false;

  constructor(private httpClient: HttpClient,  private router: Router) { }

  private initialized: boolean = false;

  ngOnInit(): void {
    this.k2_Preuzmi();
    this.getCities();
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.setupIntersectionObserver();
    }, 3000);
  }

  k2_Preuzmi() {
    if (this.isLoading || !this.hasMoreData || this.isFiltered) {
      console.log('Skipping load:', { isLoading: this.isLoading, hasMoreData: this.hasMoreData, isFiltered: this.isFiltered });
      return;
    }

    console.log(`Loading page ${this.page} with ${this.pageSize} items per page`);
    this.isLoading = true;


    let url = `${this.bazniUrl}/Apartment/Get?page=${this.page}&limit=${this.pageSize}`;

    const delayTime = this.firstLoadDone ? 1200 : 0;


    timer(delayTime).subscribe(() => {
      this.httpClient.get<Apartment[]>(url).subscribe(
        (response) => {
          if (response && response.length > 0) {
            if (this.page === 1) {
              this.totalApartments = response.length;
            }

            const startIndex = (this.page - 1) * this.pageSize;
            const endIndex = Math.min(startIndex + this.pageSize, this.totalApartments);

            const pageApartments = response.slice(startIndex, endIndex);

            console.log(`Loaded ${pageApartments.length} apartments for page ${this.page}`);
            this.sviApartmani = [...this.sviApartmani, ...pageApartments];
            this.filtriraniApartmani = [...this.sviApartmani];
            this.page++;

            if (this.sviApartmani.length >= this.totalApartments) {
              this.hasMoreData = false;
              console.log('Reached end of data');
            }
          } else {
            console.log('No more data to load');
            this.hasMoreData = false;
          }

          this.isLoading = false;
          this.firstLoadDone = true;

        },
        (error) => {
          console.error("API Request Failed:", error);
          this.isLoading = false;
          this.hasMoreData = false;
        }
      );
    });
  };

  setupIntersectionObserver() {
    if (!this.scrollAnchor || this.scrollAnchor.nativeElement.__observerSet) {
      console.log('Observer already set or scroll anchor not found');
      return;
    }

    this.scrollAnchor.nativeElement.__observerSet = true;

    const observer = new IntersectionObserver(
      (entries) => {
        if (entries[0].isIntersecting && !this.isLoading && this.hasMoreData) {
          console.log('Scroll anchor intersected, loading more data');
          this.k2_Preuzmi();
        }
      },
      {
        threshold: 0.1,
        rootMargin: '100px'
      }
    );

    observer.observe(this.scrollAnchor.nativeElement);
  }

  getCities() {
    let url = `${this.bazniUrl}/City/Get`;

    this.httpClient.get<City[]>(url).subscribe(
      (response) => {
        this.sviGradovi = response;
      },
      (error) => {
        console.error("❌ API Request Failed:", error);
      }
    );
  }

  filterCities() {
    const searchTerm = this.traziVrijednost.trim().toLowerCase();

    if (searchTerm.length > 0) {
      this.filteredCities = this.sviGradovi.filter(city =>
        city.name.toLowerCase().startsWith(searchTerm)
      );
    } else {
      this.filteredCities = this.sviGradovi;
    }

    this.showDropdown = true;
  }

  pretraziApartmane() {
    const searchTerm = this.traziVrijednost.trim().toLowerCase();

    if (!searchTerm || !this.checkInDate || !this.checkOutDate) {
      console.warn("Molimo popunite sva polja pre pretrage.");
      return;
    }

    this.isFiltered = true;

    this.filtriraniApartmani = this.sviApartmani.filter(apartman =>
      apartman.cityName.toLowerCase() === searchTerm &&
      this.isAvailable(apartman)
    );
  }

  isAvailable(apartman: Apartment): boolean {
    if (!this.checkInDate || !this.checkOutDate) {
      return false;
    }

    return true;
  }

  resetFilter() {
    this.isFiltered = false;
    this.filtriraniApartmani = [];
    this.sviApartmani = [];
    this.page = 1;
    this.hasMoreData = true;
    this.totalApartments = 0;
    this.k2_Preuzmi();
  }

  K2_odaberiDestinaciju(drzave: Drzava) {
    this.odabranaDrzava = drzave;
  }

  K2_odaberiApartment(apartman: Apartment): void {
    this.odabraniApartman = apartman;
    this.router.navigate(['/apartment', apartman.apartmentId]);
  }

  K3_OdaberiPutovanje(polazak: PlaniranaPutovanja) {
    this.odabranoPutovanje = polazak;
  }

  selectCity(city: City) {
    this.traziVrijednost = city.name;
    this.showDropdown = false;
  }

  hideDropdownWithDelay() {
    setTimeout(() => {
      this.showDropdown = false;
    }, 200);
  }

  showAllCities() {
    this.filteredCities = this.sviGradovi;
    this.showDropdown = true;
  }
}

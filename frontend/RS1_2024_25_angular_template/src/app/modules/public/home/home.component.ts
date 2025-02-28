import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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

export interface Apartment {
  apartmentId: number;
  name: string;
  description: string;
  adress: string;
  pricePerNight: number;
  cityId: number | null;
  accountID: number | null;
  apartmentImages: ApartmentImages[];
  city: City;
}

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
  @ViewChild('scrollAnchor', { static: false }) scrollAnchor!: ElementRef; // Dodato za praćenje scroll-a

  traziVrijednost: string = "";
  bazniUrl: string = "http://localhost:8000";
  globalPodaci: Drzava[] = [];
  sviApartmani: Apartment[] = [];
  odabranaDrzava: Drzava | null = null;
  odabranoPutovanje: PlaniranaPutovanja | null = null;
  odabraniApartman: Apartment | null = null;
  checkInDate: Date | null = null;
  checkOutDate: Date | null = null;
  sviGradovi: City[] = [];  // Store cities from API
  filteredCities: City[] = [];
  showDropdown: boolean = false;  // Toggle dropdown visibility

  page: number = 1;         // Trenutna strana
  isLoading: boolean = false;  // Status učitavanja
  hasMoreData: boolean = true; // Da li ima više podataka

  filtriraniApartmani: Apartment[] = [];

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.k2_Preuzmi();
    this.getCities();
  }

  ngAfterViewInit() {
    this.setupIntersectionObserver();
  }


  k2_Preuzmi() {
    if (this.isLoading || !this.hasMoreData) return; // Sprečava višestruke zahteve

    let url = `${this.bazniUrl}/Apartment/Get?page=${this.page}&limit=10`;

    this.isLoading = true;
    this.httpClient.get<Apartment[]>(url).subscribe(
      (response) => {
        if (response.length > 0) {
          this.sviApartmani = [...this.sviApartmani, ...response]; // Dodajemo apartmane
          this.filtriraniApartmani = this.sviApartmani; // ✅ Prikazujemo sve apartmane inicijalno
          this.page++; // Povećavamo broj strane
        } else {
          this.hasMoreData = false; // Sprečava dalje učitavanje ako nema više podataka
        }
        this.isLoading = false;
      },
      (error) => {
        console.error("❌ API Request Failed:", error);
        this.isLoading = false;
      }
    );
  }


  // k2_Preuzmi() {
  //   if (this.isLoading || !this.hasMoreData) return; // Sprečava višestruke zahteve
  //
  //   let url = `${this.bazniUrl}/Apartment/Get?page=${this.page}&limit=10`;
  //
  //   this.isLoading = true;
  //   this.httpClient.get<Apartment[]>(url).subscribe(
  //     (response) => {
  //       if (response.length > 0) {
  //         this.sviApartmani = [...this.sviApartmani, ...response]; // Dodaje nove apartmane umesto zamene
  //         this.page++; // Povećava broj strane
  //       } else {
  //         this.hasMoreData = false; // Sprečava dalje učitavanje ako nema više podataka
  //       }
  //       this.isLoading = false;
  //     },
  //     (error) => {
  //       console.error("❌ API Request Failed:", error);
  //       this.isLoading = false;
  //     }
  //   );
  // }

  setupIntersectionObserver() {
    const observer = new IntersectionObserver((entries) => {
      if (entries[0].isIntersecting && !this.isLoading && this.hasMoreData) {
        this.k2_Preuzmi(); // Učitava nove podatke kad korisnik dođe do dna liste
      }
    }, { threshold: 1.0 });

    if (this.scrollAnchor) {
      observer.observe(this.scrollAnchor.nativeElement);
    }
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
        city.name.toLowerCase().includes(searchTerm) ||
        city.country.name.toLowerCase().includes(searchTerm)
      );
    } else {
      this.filteredCities = this.sviGradovi;
    }

    this.showDropdown = true;
  }


  filtrirajApartmane() {
    const searchTerm = this.traziVrijednost.trim().toLowerCase();

    if (searchTerm.length > 0) {
      this.filtriraniApartmani = this.sviApartmani.filter(apartman =>
        apartman.city.name.toLowerCase() === searchTerm // ✅ Prikazuje samo apartmane iz tog grada
      );
    } else {
      this.filtriraniApartmani = this.sviApartmani; // ✅ Ako nema pretrage, prikaži sve
    }
  }





  K2_odaberiDestinaciju(drzave: Drzava) {
    this.odabranaDrzava = drzave;
  }

  K2_odaberiApartment(apartman: Apartment) {
    this.odabraniApartman = apartman;
  }

  K3_OdaberiPutovanje(polazak: PlaniranaPutovanja) {
    this.odabranoPutovanje = polazak;
  }

  selectCity(city: City) {
    this.traziVrijednost = city.name; // Postavi samo ime grada
    this.showDropdown = false;
    this.filtrirajApartmane(); // ✅ Automatski filtrira apartmane kada klikneš na grad
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

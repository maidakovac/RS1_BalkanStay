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
  isFiltered: boolean = false; // Praćenje da li je pretraga aktivna
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
    if (this.isLoading || !this.hasMoreData || this.isFiltered) return; // 🛑 STOP dupli pozivi

    console.log(`🔄 Učitavam podatke za Page ${this.page}`);

    let url = `${this.bazniUrl}/Apartment/Get?page=${this.page}&limit=10`;

    console.time(`⏳ API Load Time (Page ${this.page})`); // 🕒 Početak merenja vremena

    this.isLoading = true;
    this.httpClient.get<Apartment[]>(url).subscribe(
      (response) => {
        console.timeEnd(`⏳ API Load Time (Page ${this.page})`); // 🕒 Kraj merenja vremena

        if (response.length > 0) {
          this.sviApartmani = [...this.sviApartmani, ...response];
          this.filtriraniApartmani = [...this.sviApartmani];
          this.page++;
        } else {
          this.hasMoreData = false; // 🚨 Nema više podataka, stopiraj infinite scroll
        }

        this.isLoading = false;
      },
      (error) => {
        console.error("❌ API Request Failed:", error);
        this.isLoading = false;
      }
    );
  }





  setupIntersectionObserver() {
    if (!this.scrollAnchor || this.scrollAnchor.nativeElement.__observerSet) return; // 🛑 Ako je već postavljen observer, prekini

    this.scrollAnchor.nativeElement.__observerSet = true; // ✅ Postavljamo flag da observer ne bude dodan više puta

    const observer = new IntersectionObserver((entries) => {
      if (entries[0].isIntersecting && !this.isLoading && this.hasMoreData) {
        console.log("🔄 Učitavam nove apartmane...");
        this.k2_Preuzmi();
      }
    }, { threshold: 1.0 });

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
        city.name.toLowerCase().startsWith(searchTerm) // 🟢 Filtrira samo gradove koji počinju sa unetim slovima
      );
    } else {
      this.filteredCities = this.sviGradovi; // 🟢 Ako nema unosa, prikazuje sve gradove
    }

    this.showDropdown = true;
  }




  pretraziApartmane() {
    const searchTerm = this.traziVrijednost.trim().toLowerCase();

    // Proveravamo da li su sva polja popunjena
    if (!searchTerm || !this.checkInDate || !this.checkOutDate) {
      console.warn("Molimo popunite sva polja pre pretrage.");
      return;
    }

    // Aktiviramo filter
    this.isFiltered = true;

    // Filtriramo apartmane
    this.filtriraniApartmani = this.sviApartmani.filter(apartman =>
      apartman.city.name.toLowerCase() === searchTerm &&
      this.isAvailable(apartman)
    );
  }


  isAvailable(apartman: Apartment): boolean {
    // Ova metoda bi trebalo da proverava dostupnost apartmana na osnovu datuma
    // Ako backend vraća dostupnost, možeš je proveriti na osnovu dostupnih podataka

    if (!this.checkInDate || !this.checkOutDate) {
      return false; // Ako nema izabranih datuma, apartman nije dostupan
    }

    // Ova provera je primer, možeš je proširiti zavisno od dostupnih podataka
    // Trenutno vraća true za sve apartmane
    return true;
  }




  resetFilter() {
    this.isFiltered = false;
    this.filtriraniApartmani = [];
    this.sviApartmani = [];
    this.page = 1;
    this.hasMoreData = true;
    this.k2_Preuzmi(); // Ponovo pokreni učitavanje od prve stranice
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

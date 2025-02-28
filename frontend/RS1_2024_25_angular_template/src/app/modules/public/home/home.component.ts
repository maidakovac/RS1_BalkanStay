import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';


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
  cityId: number| null;
  accountID: number| null;
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

export interface  Image{
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
export class HomeComponent implements OnInit {
  traziVrijednost: string = "";
  bazniUrl: string = "http://localhost:8000";
  globalPodaci: Drzava[] = [];
  sviApartmani: Apartment[] = [];
  odabranaDrzava: Drzava | null = null;
  odabranoPutovanje: PlaniranaPutovanja | null = null;
  odabraniApartman: Apartment| null = null;
  checkInDate: Date | null = null;
  checkOutDate: Date | null = null;
  sviGradovi: City[] = [];  // Store cities from API
  filteredCities: City[] = [];
  showDropdown: boolean = false;  // Toggle dropdown visibility






  constructor(private httpClient: HttpClient) {

  }

  getFiltiratiPodaci() {
    if (this.traziVrijednost.length > 2) {
      return this.globalPodaci.filter(x => x.drzava.startsWith(this.traziVrijednost) || x.boravakGradovi.filter((g: any) => g.nazivGrada === this.traziVrijednost).length > 0)
    } else {
      return this.globalPodaci
    }
  }


  ngOnInit(): void {
    this.k2_Preuzmi();
    this.getCities();
  }

  k2_Preuzmi() {
    let url = `${this.bazniUrl}/Apartment/Get`;

    this.httpClient.get<Apartment[]>(url).subscribe(
      (response) => {
        this.sviApartmani = response;
        console.log(this.sviApartmani)
      },
      (error) => {
        console.error("❌ API Request Failed:", error);
      }
    );
  }


  getCities() {
    let url = `${this.bazniUrl}/City/Get`; // Make sure the endpoint is correct

    this.httpClient.get<City[]>(url).subscribe(
      (response) => {
        console.log("✅ API Response:", response); // Debugging
        this.sviGradovi = response; // Store fetched cities
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
      this.filteredCities = this.sviGradovi; // ✅ Prikazuje sve gradove ako je polje prazno
    }

    this.showDropdown = true; // ✅ Dropdown ostaje otvoren dok korisnik piše
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
    this.traziVrijednost = `${city.name}, ${city.country.name}`;
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

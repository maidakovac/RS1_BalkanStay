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
  city: City[]
}

export interface City {
  id: number;
  name: string;
  countryId: number;
  country: Country[]
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
  baseUrl = "https://wrd-fit.info";
  bazniUrl: string = "http://localhost:8000";
  globalPodaci: Drzava[] = [];
  sviApartmani: Apartment[] = [];
  odabranaDrzava: Drzava | null = null;
  odabranoPutovanje: PlaniranaPutovanja | null = null;
  odabraniApartman: Apartment| null = null;

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
    this.k1_Preuzmi();
    this.k2_Preuzmi();
  }

  k1_Preuzmi() {

    let url = `${this.baseUrl}/Ispit20240921/GetNovePonude`

    this.httpClient.get<GetPodaciResponse>(url).subscribe((x) => {
      this.globalPodaci = x.podaci;
    });
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




  K2_odaberiDestinaciju(drzave: Drzava) {
    this.odabranaDrzava = drzave;
  }

  K2_odaberiApartment(apartman: Apartment) {
    this.odabraniApartman = apartman;
  }

  K3_OdaberiPutovanje(polazak: PlaniranaPutovanja) {
    this.odabranoPutovanje = polazak;
  }
}

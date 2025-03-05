import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css'],
  standalone: false
})
export class ContactUsComponent implements OnInit {
  countries: string[] = []; // lista svih drzaba
  filteredCountries: string[] = []; // filtrirane drzave
  countryInput: string = ''; // unesena vrijednost u box za drzavu
  showDropdown: boolean = false; // kontrolise prikazivanje dropdown liste

  constructor(private http: HttpClient) {}

  ngOnInit() {
    // preuzimanje drzava sa REST API-ja
    this.http.get<any[]>('https://restcountries.com/v3.1/all').subscribe(data => {
      this.countries = data.map(country => country.name.common).sort();
      this.filteredCountries = this.countries; // Inicijalno prikaži sve države
    });
  }

  // filtriranje drzava dok korisnik kuca
  filterCountries() {
    this.filteredCountries = this.countries.filter(country =>
      country.toLowerCase().startsWith(this.countryInput.toLowerCase())
    );
  }

  // odabir drzave iz dropdowna
  selectCountry(country: string) {
    this.countryInput = country;
    this.showDropdown = false;
  }

  // sakrivanje dropdowna
  onBlur() {
    setTimeout(() => {
      this.showDropdown = false;
    }, 200);
  }

  // slanje forme
  onSubmit(form: NgForm) {
    if (form.invalid) {
      console.log('Form is invalid');
      return;
    }

    console.log('Form submitted successfully!', form.value);
    // ovdje dodati funkcije za slanje forme
  }
}

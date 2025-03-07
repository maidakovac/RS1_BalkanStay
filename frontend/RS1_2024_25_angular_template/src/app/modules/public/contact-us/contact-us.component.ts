import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { ContactService } from './contact-service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css'],
  standalone: false
})
export class ContactUsComponent implements OnInit {
  submitted = false;
  countries: string[] = []; // lista svih drzaba
  filteredCountries: string[] = []; // filtrirane drzave
  countryInput: string = ''; // unesena vrijednost u box za drzavu
  showDropdown: boolean = false; // kontrolise prikazivanje dropdown liste
  isValidCountry = false;
  isLoading = false; // prikaz loadera prilikom slanja
  messageStatus: string = ''; // obavijest o slanju poruke
  messageError: string = '';  // greska slanja

  constructor(private http: HttpClient, private contactService: ContactService) {}

  messages: any[] = [];

  loadMessages() {
    this.contactService.getMessages().subscribe({
      next: (data) => {
        this.messages = data;
      },
      error: (err) => {
        console.error("Error fetching messages:", err);
      }
    });
  }

  ngOnInit() {
    // preuzimanje drzava sa REST API-ja
    this.http.get<any[]>('https://restcountries.com/v3.1/all').subscribe(data => {
      this.countries = data.map(country => country.name.common).sort();
      this.filteredCountries = this.countries; // Inicijalno prikaži sve države
    });

    this.loadMessages();
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
    this.isValidCountry = true;
    this.showDropdown = false;
  }

  validateCountry() {
    this.isValidCountry = this.countries.includes(this.countryInput);
  }

  // sakrivanje dropdowna
  onBlur() {
    setTimeout(() => {
      this.showDropdown = false;
    }, 200);
  }


  // slanje forme
  onSubmit(form: NgForm) {
    this.submitted = true;
    this.validateCountry();

    if (form.valid && this.isValidCountry) {
      this.isLoading = true;
      const formData = {
        name: form.value.name,
        email: form.value.mail,
        country: this.countryInput,
        message: form.value.subject
      };

      this.contactService.sendMessage(formData).subscribe({
        next: (response) => {
          console.log("Message sent successfully!", response);
          this.messageStatus = "Your message has been sent successfully! ✅";
          this.messageError = "";
          form.reset();
          this.submitted = false;
          this.isValidCountry = false;
        },
        error: (err) => {
          console.error("Error sending message:", err);
          this.messageError = "Error sending message. Please try again. ❌";
          this.messageStatus = "";
        },
        complete: () => {
          this.isLoading = false;
        }
      });
    }
  }

}

import { Component, OnInit, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css'],
  standalone: false
})
export class ContactUsComponent implements OnInit, AfterViewInit {
  countries: string[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    // Dinamičko preuzimanje država sa REST API-ja
    this.http.get<any[]>('https://restcountries.com/v3.1/all').subscribe(data => {
      this.countries = data.map(country => country.name.common).sort();
    });
  }

  ngAfterViewInit() {
    const form = document.getElementById('contactForm') as HTMLFormElement;
    const emailInput = document.getElementById('mail') as HTMLInputElement;
    const errorMessage = document.createElement('small');

    errorMessage.style.color = 'red';
    emailInput.parentNode?.insertBefore(errorMessage, emailInput.nextSibling);

    emailInput.addEventListener('input', () => {
      const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      if (!emailPattern.test(emailInput.value)) {
        errorMessage.textContent = '';
      } else {
        errorMessage.textContent = '';
      }
    });

    form.addEventListener('submit', (event) => {
      if (!emailInput.value.match(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)) {
        event.preventDefault(); // Sprjecava slanje forme ako e-mail nije validan
        errorMessage.textContent = 'Please enter a valid email address.';
      }
    });

    const countrySelect = document.getElementById('country') as HTMLSelectElement;

    countrySelect.addEventListener('focus', () => {
      countrySelect.setAttribute('size', '7'); // Prikazuje 7 stavki kada se otvori
    });

    countrySelect.addEventListener('blur', () => {
      countrySelect.removeAttribute('size'); // Vrati na stari dropdown
    });
  }
}

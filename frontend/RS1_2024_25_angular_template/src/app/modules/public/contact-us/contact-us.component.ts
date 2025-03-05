import {Component, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css',
  standalone: false
})
export class ContactUsComponent implements AfterViewInit {
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
        alert('Invalid email! Please enter a valid email address.');
      }
    });
  }
}

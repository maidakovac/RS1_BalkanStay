import {Component} from '@angular/core';
import {HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-forgot-password',
  standalone: false,
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css'
})
export class ForgotPasswordComponent {
  email: string = '';
  message: string = '';

  constructor(private http: HttpClient) {}


  onSendResetLink() {
    if (!this.email) {
      this.message = "Email is required.";
      return;
    }

    this.http.post('http://localhost:8000/auth/password/forgot',
      { email: this.email },
      { headers: { 'Content-Type': 'application/json' } } // <-- Dodano
    ).subscribe({
      next: (response: any) => {
        this.message = "Password reset link has been sent to your email.";
      },
      error: (error) => {
        this.message = error.error.message || "Error sending email.";
      }
    });
  }

}

import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
  standalone: false
})

export class RegisterComponent {
  name: string = '';
  surname: string = '';
  username: string = '';
  email: string = '';
  password: string = '';
  message: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  onRegister() {
    if (!this.name || !this.surname || !this.username || !this.email || !this.password) {
      this.message = "All fields are required!";
      return;
    }

    const userData = {
      email: this.email,
      password: this.password,
      firstName: this.name,  // ✅ Changed
      lastName: this.surname, // ✅ Changed
      userName: this.username // ✅ Changed (Backend expects userName, not username)
    };

    this.http.post('http://localhost:8000/auth/register', userData, {
      headers: { 'Content-Type': 'application/json' }
    })
      .subscribe({
        next: (response: any) => {
          this.message = "Registration successful! Redirecting to login...";
          setTimeout(() => this.router.navigate(['/auth/login']), 3000);
        },
        error: (error) => {
          this.message = error.error.message || "Registration failed.";
          console.error("Registration error:", error);
        }
      });
  }

}

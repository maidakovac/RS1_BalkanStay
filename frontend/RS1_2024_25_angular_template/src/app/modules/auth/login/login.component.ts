import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthLoginEndpointService, LoginRequest } from '../../../endpoints/auth-endpoints/auth-login-endpoint.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false
})
export class LoginComponent {
  loginRequest: LoginRequest = { username: '', password: '' };
  errorMessage: string | null = null;

  constructor(private authLoginService: AuthLoginEndpointService, private router: Router) {}

  onLogin(): void {
    if ((!this.loginRequest.email && !this.loginRequest.username) || !this.loginRequest.password) {
      this.errorMessage = 'Please enter email or username, and password is required';
      return;
    }

    console.log('🟢 Sending login request:', this.loginRequest);

    this.authLoginService.handleAsync(this.loginRequest).subscribe({
      next: (response) => {
        console.log('🟢 API Response:', response);

        if (response.accountID) {
          console.log('🔐 2FA required, storing account ID:', response.accountID);
          localStorage.setItem('authinfo', JSON.stringify({ userId: response.accountID }));
          this.router.navigate(['/auth/two-factor']);
        } else {
          console.error('❌ Login failed:', response.message);
          this.errorMessage = response.message;
        }
      },
      error: (error) => {
        console.error('❌ Login error:', error);
        this.errorMessage = error.error?.message || 'Incorrect username or password';
      }
    });
  }
}

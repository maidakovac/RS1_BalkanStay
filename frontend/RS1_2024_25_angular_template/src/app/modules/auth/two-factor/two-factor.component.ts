import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

interface TwoFactorRequest {
  userId: number;
  token: string;
}

interface TwoFactorResponse {
  message: string;
  token: string;
  myAuthInfo: any;
}

@Component({
  selector: 'app-two-factor',
  templateUrl: './two-factor.component.html',
  styleUrls: ['./two-factor.component.css'],
  standalone: false
})
export class TwoFactorComponent {
  userId: number | null = null;
  code: string = '';
  errorMessage: string | null = null;

  constructor(private http: HttpClient, private router: Router) {
    const authInfo = localStorage.getItem('authinfo');
    if (authInfo) {
      try {
        const parsedAuthInfo = JSON.parse(authInfo);
        this.userId = parsedAuthInfo.userId;
        console.log('🟢 Loaded userId for 2FA:', this.userId);
      } catch (error) {
        console.error('❌ Error parsing authinfo from localStorage:', error);
        this.errorMessage = 'User ID is missing. Please log in again.';
      }
    } else {
      console.error('❌ No authinfo found in localStorage!');
      this.errorMessage = 'User ID is missing. Please log in again.';
    }
  }

  verify2FA(): void {
    if (!this.code || !this.userId) {
      this.errorMessage = 'Please enter the 2FA code';
      console.error('❌ 2FA verification failed: Missing code or userId');
      return;
    }

    console.log('🔐 Sending 2FA verification:', { userId: this.userId, token: this.code });



    this.http.post<TwoFactorResponse>('http://localhost:8000/auth/verify-2fa', {
      userId: this.userId,
      token: this.code
    }).subscribe({
      next: (response) => {
        console.log('✅ 2FA verification successful, received token:', response.token);
        localStorage.setItem('my-auth-token', JSON.stringify(response));
        this.router.navigate(['/public/home']);
      },
      error: (error: any) => {
        this.errorMessage = 'Invalid 2FA code';
        console.error('❌ 2FA error:', error);
      }
    });
  }
}

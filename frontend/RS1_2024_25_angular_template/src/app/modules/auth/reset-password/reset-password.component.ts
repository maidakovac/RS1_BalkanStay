import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-reset-password',
  standalone: false,
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  token: string = '';
  newPassword: string = '';
  confirmPassword: string = '';
  message: string = '';

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    // Get the token from the URL
    this.route.queryParams.subscribe(params => {
      this.token = params['token'];
    });
  }

  onResetPassword() {
    if (this.newPassword !== this.confirmPassword) {
      this.message = "Passwords do not match!";
      return;
    }

    this.http.post('http://localhost:8000/auth/password/reset', {
      token: this.token,
      newPassword: this.newPassword
    }).subscribe({
      next: () => {
        this.message = "Password has been successfully reset.";
        setTimeout(() => this.router.navigate(['/auth/login']), 3000);
      },
      error: (error) => {
        this.message = error.error.message || "Error resetting password.";
      }
    });
  }
}

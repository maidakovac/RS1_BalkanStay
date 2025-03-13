import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {AuthLoginEndpointService, LoginRequest} from '../../../endpoints/auth-endpoints/auth-login-endpoint.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false
})
export class LoginComponent {
  loginRequest: LoginRequest = { username: 'amar', password: 'password'};
  errorMessage: string | null = null;

  constructor(private authLoginService: AuthLoginEndpointService, private router: Router) {
  }

  onLogin(): void {
    if ((!this.loginRequest.email && !this.loginRequest.username) || !this.loginRequest.password) {
      this.errorMessage = 'Please enter email or username, and password is required';
      return;
    }

    console.log(this.loginRequest);

    this.authLoginService.handleAsync(this.loginRequest).subscribe({
      next: () => {
        console.log('Login successful');
        this.router.navigate(['/admin']);
      },
      error: (error: any) => {
        this.errorMessage = 'Incorrect username or password';
        console.error('Login error:', error);
      }
    });
  }

}

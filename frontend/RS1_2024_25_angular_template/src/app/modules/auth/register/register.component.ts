import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {MyAuthService, RegisterRequest } from '../../../services/auth-services/my-auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
  standalone: false
})

export class RegisterComponent {
  registerForm: FormGroup;
  errorMessage: string = '';

  constructor(private router: Router, private authService: MyAuthService, private fb: FormBuilder)
  {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required]
    });
  }

  onRegister() {
    if (this.registerForm.invalid) return;

    const registerData: RegisterRequest = this.registerForm.value;

    console.log(registerData)

    this.authService.register(registerData).subscribe({
      next: (response) => {
        console.log('Registration successful:', response);
        this.router.navigateByUrl('/auth/login');
      },
      error: (error) => {
        this.errorMessage = error.message;
      }
    });

  }

}

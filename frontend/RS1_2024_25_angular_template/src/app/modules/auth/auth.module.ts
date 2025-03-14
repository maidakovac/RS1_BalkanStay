import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import {AuthRoutingModule} from './auth-routing.module';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';
import {TwoFactorComponent} from './two-factor/two-factor.component';
import {LogoutComponent} from './logout/logout.component';
import {AuthLayoutComponent} from './auth-layout/auth-layout.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';


import {MatButton, MatButtonModule} from '@angular/material/button';
import {MatSlideToggle, MatSlideToggleModule} from '@angular/material/slide-toggle';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    TwoFactorComponent,
    AuthLayoutComponent,
    ForgotPasswordComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    AuthRoutingModule,
    MatButtonModule,
    MatSlideToggleModule,
    MatButton,
    MatSlideToggle,
  ],
  providers: []
})
export class AuthModule { }

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { MyConfig } from '../../my-config';
import { MyAuthService } from '../../services/auth-services/my-auth.service';
import { LoginTokenDto } from '../../services/auth-services/dto/login-token-dto';
import { MyBaseEndpointAsync } from '../../helper/my-base-endpoint-async.interface';
import {Observable} from 'rxjs';

export interface LoginRequest {
  email?: string;
  username?: string;
  password: string;
}

export interface LoginResponse {
  message: string;
  accountID?: number;
}

@Injectable({
  providedIn: 'root'
})
export class AuthLoginEndpointService implements MyBaseEndpointAsync<LoginRequest, LoginResponse> {
  private apiUrl = `${MyConfig.base_url}/auth/login`;

  constructor(private httpClient: HttpClient, private myAuthService: MyAuthService) {}

  handleAsync(request: LoginRequest): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>(this.apiUrl, request);
  }
}

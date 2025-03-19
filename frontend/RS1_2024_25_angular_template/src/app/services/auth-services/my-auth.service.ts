import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {MyAuthInfo} from "./dto/my-auth-info";
import {LoginTokenDto} from './dto/login-token-dto';
import {catchError, Observable, throwError} from 'rxjs';

export interface RegisterRequest {
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  userName: string;
}

export interface Account {
  accountID: number;
  email: string;
  userName: string;
  firstName: string;
  lastName: string;
}

export interface RegisterResponse {
  account: Account;
}


@Injectable({providedIn: 'root'})
export class MyAuthService {
  constructor(private httpClient: HttpClient) {
  }

  getMyAuthInfo(): MyAuthInfo | null {
    return this.getLoginToken()?.myAuthInfo ?? null;
  }

  isLoggedIn(): boolean {
    return this.getMyAuthInfo() != null && this.getMyAuthInfo()!.isLoggedIn;
  }

  isAdmin(): boolean {
    return this.getMyAuthInfo()?.isAdmin ?? false;
  }

  isOwner(): boolean {
    return this.getMyAuthInfo()?.isOwner ?? false;
  }

  setLoggedInUser(x: LoginTokenDto | null) {
    if (x == null) {
      window.localStorage.setItem("my-auth-token", '');
    } else {
      window.localStorage.setItem("my-auth-token", JSON.stringify(x));
    }
  }

  getLoginToken(): LoginTokenDto | null {
    let tokenString = window.localStorage.getItem("my-auth-token") ?? "";
    try {
      return JSON.parse(tokenString);
    } catch (e) {
      return null;
    }
  }


  register(userData: RegisterRequest): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>(`http://localhost:8000/auth/register`, userData)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('Client-side error:', error.error.message);
    } else {
      console.error(`Server-side error: ${error.status}, Message: ${error.error?.message || error.message}`);
    }
    return throwError(() => new Error(error.error?.message || 'Something went wrong. Please try again.'));
  }


}

import { Component, OnInit } from '@angular/core';
import {MyAuthInfo} from '../../../services/auth-services/dto/my-auth-info';
import {MyAuthService} from '../../../services/auth-services/my-auth.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-public-layout',
  templateUrl: './public-layout.component.html',
  styleUrls: ['./public-layout.component.css'],
  standalone: false
})
export class PublicLayoutComponent implements OnInit {
  authInfo: MyAuthInfo | null = null;
  dropdownOpen: boolean = false;

  constructor(private authService: MyAuthService, private router: Router) {}

  ngOnInit() {
    this.loadAuthInfo();
  }

  loadAuthInfo() {
    const storedAuth = localStorage.getItem('my-auth-token');

    if (storedAuth) {
      const parsedAuth = JSON.parse(storedAuth);

      // Extracting the nested 'myAuthInfo' object
      if (parsedAuth && parsedAuth.myAuthInfo) {
        this.authInfo = parsedAuth.myAuthInfo as MyAuthInfo;
      } else {
        this.authInfo = null;
      }
    } else {
      this.authInfo = null; // No user logged in
    }
  }


  isLoggedIn(): boolean {
    return this.authInfo !== null && this.authInfo.isLoggedIn;
  }

  getUserName(): string {
    return this.authInfo && this.authInfo.firstName ? this.authInfo.firstName : '';
  }

  toggleDropdown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  logout() {
    this.authService.setLoggedInUser(null);
    localStorage.removeItem('my-auth-token');
    this.router.navigate(['/auth/login']);
  }
}

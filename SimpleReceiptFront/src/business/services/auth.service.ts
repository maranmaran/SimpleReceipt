import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import * as moment from 'moment';


@Injectable()
export class AuthService {
  baseUrl = 'api/account/';
  headers = { headers: { 'Content-Type': 'application/json' } };

  public badLogin = false;
  isLoading = new EventEmitter<boolean>();


  viewAsChanged = new EventEmitter<void>();

  constructor(private http: HttpClient, private router: Router) { }

  login(username: string, password: string, rememberMe: string) {
    this.isLoading.emit(true);
    return this.http.post(this.baseUrl + 'login',
      { username, password, rememberMe })
      .subscribe(
        (response: any) => {
          this.setSession(response);
          this.isLoading.emit(false);
          this.router.navigate(['/application']);
        },
       err => { this.isLoading.emit(false); console.log(err); });
  }

  private setSession(authResult) {
    const expiresAt = moment().add(authResult.timeout, 'second');
    localStorage.setItem('userId', authResult.userId);
    localStorage.setItem('token', authResult.token);
    localStorage.setItem('expires_at', JSON.stringify(expiresAt.valueOf()));
  }

  logout() {
    localStorage.removeItem('userId');
    localStorage.removeItem('token');
    localStorage.removeItem('expires_at');

    this.router.navigate(['/login']);
  }

  public isLoggedIn() {
    return moment().isBefore(this.getExpiration());
  }


  isLoggedOut() {
    return !this.isLoggedIn();
  }

  getExpiration() {
    const expiration = localStorage.getItem('expires_at');
    const expiresAt = JSON.parse(expiration);
    return moment(expiresAt);
  }

  getUserId() {
    return localStorage.getItem('userId');
  }
}



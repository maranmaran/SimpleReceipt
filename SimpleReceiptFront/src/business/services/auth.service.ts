import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import * as moment from 'moment';


@Injectable()
export class AuthService {
  baseUrl = 'api/Account/';
  headers = { headers: { 'Content-Type': 'application/json' } };

  public badLogin = false;

  viewAsChanged = new EventEmitter<void>();

  constructor(private http: HttpClient, private router: Router) { }

  login(username: string, password: string, rememberMe: string) {
    return this.http.post(this.baseUrl + 'Login',
      { username, password, rememberMe });
  }

  public setSession(authResult) {
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



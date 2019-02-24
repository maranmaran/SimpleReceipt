import { AuthService } from './auth.service';
import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cafe } from '../models/cafe.model';
import { plainToClass } from 'class-transformer';

@Injectable()
export class CafeService implements OnInit {

  headers = { headers: { 'Content-Type': 'application/json' } };
  cafes: Cafe[] = [];

  constructor(
    private authService: AuthService,
    private http: HttpClient
  ) { }

  ngOnInit() {
  }

  newInstance(plainObject: Cafe) {
    return plainToClass(Cafe, plainObject);
  }

  createInstances(items: Cafe[]): Array<Cafe> {
    const model = items;
    const viewModel = new Array<Cafe>();
    model.forEach(modelItem => {
      viewModel.push(this.newInstance(modelItem));
    });

    return viewModel;
  }

  automaticLogin() {
    console.log('Logging in');
    this.authService.login('admin', 'admin', 'false');
  }

  getAllCafes(url = 'api/Cafe/GetAllCafes/') {
    if (this.cafes.length === 0) {
      this.automaticLogin();
      this.http.get(url + this.authService.getUserId(), this.headers).subscribe(
        (res: any) => this.cafes = this.createInstances(res),
        err => console.log(err)
      );
    }
  }

  getAllWaiters(cafeId: string, url = 'api/Cafe/GetAllWaiters/') {
    return this.http.get(url + cafeId, this.headers);
  }

  getAllTables(cafeId: string, url = 'api/Cafe/GetAllTables/') {
    return this.http.get(url + cafeId, this.headers);
  }

  getAllPriceTableQueries(cafeId: string, url = 'api/Cafe/GetAllPriceTableQueries/') {
    return this.http.get(url + cafeId, this.headers);
  }
}

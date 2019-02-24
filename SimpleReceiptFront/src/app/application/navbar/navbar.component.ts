import { AuthService } from './../../../business/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { CafeService } from 'src/business/services/cafe.service';
import { Cafe } from 'src/business/models/cafe.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {


  constructor(
    public cafeService: CafeService) {
    }

  ngOnInit() {
    this.cafeService.getAllCafes();
  }
}

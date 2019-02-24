import { ApplicationComponent } from './application/application.component';
import { LoginComponent } from './authentication/login/login.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ErrorComponent } from './handle-pages/error/error.component';
import { NavbarComponent } from './application/navbar/navbar.component';
import { ReceiptsComponent } from './application/receipts/receipts.component';
import { ReceiptsListComponent } from './application/receipts/receipts-list/receipts-list.component';
import { ReceiptDetailsComponent } from './application/receipts/receipt-details/receipt-details.component';
import { HttpInterceptor } from 'src/business/interceptors/http.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './modules/app-routing.module';
import { MaterialModule } from './modules/material.module';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { AuthService } from '../business/services/auth.service';
import { ErrorHelper } from '../business/helpers/error.helper';
import { CreateOrEditReceiptComponent } from './application/receipts/create-or-edit-receipt/create-or-edit-receipt.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CafeService } from '../business/services/cafe.service';

@NgModule({
  declarations: [
    AppComponent,
    ErrorComponent,
    NavbarComponent,
    ApplicationComponent,
    ReceiptsComponent,
    ReceiptsListComponent,
    CreateOrEditReceiptComponent,
    ReceiptDetailsComponent,
    LoginComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptor, multi: true },
    AuthService,
    CafeService,
    ErrorHelper
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

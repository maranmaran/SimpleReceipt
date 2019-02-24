import { LoginComponent } from './authentication/login/login.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { ErrorComponent } from './handle-pages/error/error.component';
import { NavbarComponent } from './application/navbar/navbar.component';
import { ReceiptsComponent } from './application/receipts/receipts.component';
import { ReceiptsListComponent } from './application/receipts/receipts-list/receipts-list.component';
import { CreateOrEditReceiptComponent } from './application/receipts/receipts-list/create-or-edit-receipt/create-or-edit-receipt.component';
import { ReceiptDetailsComponent } from './application/receipts/receipt-details/receipt-details.component';
import { HttpInterceptor } from 'src/business/interceptors/http.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ErrorComponent,
    NavbarComponent,
    ReceiptsComponent,
    ReceiptsListComponent,
    CreateOrEditReceiptComponent,
    ReceiptDetailsComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    AppRoutingModule,
  ],
  providers: [
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

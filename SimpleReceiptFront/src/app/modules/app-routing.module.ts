// tslint:disable-next-line:max-line-length
import { ApplicationComponent } from './../application/application.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../authentication/login/login.component';
import { AppComponent } from '../app.component';
import { ErrorComponent } from '../handle-pages/error/error.component';
import { ReceiptsComponent } from '../application/receipts/receipts.component';
import { CreateOrEditReceiptComponent } from '../application/receipts/create-or-edit-receipt/create-or-edit-receipt.component';

const routes: Routes = [
  { path: '', component: ApplicationComponent,
              children: [
                { path: '',  redirectTo: '', pathMatch: 'full' },
                { path: 'receipts/:id', component: ReceiptsComponent},
                { path: 'create-receipt/:id', component: CreateOrEditReceiptComponent},
          ]},
  { path: 'login', component: LoginComponent},
  { path: 'error', component: ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

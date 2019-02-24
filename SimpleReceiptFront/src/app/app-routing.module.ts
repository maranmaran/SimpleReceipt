import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './authentication/login/login.component';
import { AppComponent } from './app.component';
import { ErrorComponent } from './handle-pages/error/error.component';
import { ReceiptsComponent } from './application/receipts/receipts.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'application', component: AppComponent,
              children: [
                { path: 'receipts', component: ReceiptsComponent},
          ]},
  { path: 'login', component: LoginComponent},
  { path: 'error', component: ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

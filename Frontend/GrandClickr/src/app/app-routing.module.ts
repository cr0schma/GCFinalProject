import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AzStorageComponent } from './az-storage/az-storage.component';
import { LoginPageComponent } from './login-page/login-page.component';

const routes: Routes = [
  { path: 'az-storage', component: AzStorageComponent },
  { path: '', component: LoginPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

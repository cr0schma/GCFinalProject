import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AzStorageComponent } from './az-storage/az-storage.component';

const routes: Routes = [
  { path: '', component: AzStorageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

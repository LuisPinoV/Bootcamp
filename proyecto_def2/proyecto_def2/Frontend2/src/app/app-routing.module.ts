import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { VitaLuxComponent } from './pages/vita-lux/vita-lux.component';
import { HomeComponent } from './home/home.component';
import { StatsComponent } from './stats/stats.component';

const routes: Routes = [
  { path: '', redirectTo: '/vitalux', pathMatch: 'full' },
  { path: 'vitalux', component: VitaLuxComponent },
  { path: 'patient-details/:id', component: PatientDetailsComponent },
  { path:'home', component:HomeComponent},
  { path: 'stats', component: StatsComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


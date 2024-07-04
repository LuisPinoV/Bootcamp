import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { ReactiveFormsModule } from '@angular/forms';  // Importa ReactiveFormsModule
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VitaLuxComponent } from './pages/vita-lux/vita-lux.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { VitalSignsChartsComponent } from './vital-signs-charts/vital-signs-charts.component';
import { HomeComponent } from './home/home.component';
import { StatsComponent } from './stats/stats.component';


@NgModule({
  declarations: [
    AppComponent,
    VitaLuxComponent,
    PatientDetailsComponent,
    VitalSignsChartsComponent,
    HomeComponent,
    StatsComponent //Este es el que estoy ocupando ahora
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CanvasJSAngularChartsModule,  // Asegúrate de importar CanvasJS aquí
    ReactiveFormsModule,  // Asegúrate de incluirlo aquí
    HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

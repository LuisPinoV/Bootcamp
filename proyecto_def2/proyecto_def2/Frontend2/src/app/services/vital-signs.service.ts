import { Injectable } from '@angular/core';
import { ApiService } from '../service/api.service'; // Ajusta la ruta según la estructura de tu proyecto
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface VitalSign {
  id: number;
  id_paciente:string;
  name: string; // Agrego el nombre pero no debe salir en la tabla
  age: number;
  bloodType: string;
  heartRate: number;
  bloodPressure: string;
  respiratoryRate: number;
  temperature: number;
}

@Injectable({
  providedIn: 'root'
})
export class VitalSignsService {

  private vitalSigns: VitalSign[] = [];

  constructor(private apiService: ApiService) {
    this.fetchVitalSigns();
  }

  fetchVitalSigns(): void {
    this.apiService.getData().pipe(
      map(data => {
        return data.map((item: any) => ({
          id: item.Id,
          id_paciente: item.Id_paciente,
          name: 'Luis',
          age: item.Edad,
          heartRate: item.Pulse,
          bloodPressure: item.Pres,
          respiratoryRate: item.Rpm,
          temperature: item.Temp,
          bloodType: 'Pino'
        }));
      })
    ).subscribe((transformedData: VitalSign[]) => {
      this.vitalSigns = transformedData;
    });
  }

  getVitalSigns(): VitalSign[] {
    return this.vitalSigns;
  }

  getPatientById(id: number): VitalSign | undefined {
    return this.vitalSigns.find(sign => sign.id === id);
  }
}

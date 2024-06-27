import { Injectable } from '@angular/core';

export interface VitalSign {
  id: number;
  name: string; //Agrego el nombre pero no debe salir en la tabla
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
  //Estos datos despues los deberia reemplazarl el simulador
  //Nota: El nombre y el tipo de sangre es algo que yo puse pero es opcional, puede sacarse.
  private vitalSigns: VitalSign[] = [
    { id: 1, name: 'John Doe', age: 25, heartRate: 72, bloodPressure: '120/80', respiratoryRate: 16, temperature: 98.6, bloodType: 'O+' },
    { id: 2, name: 'Jane Smith', age: 30, heartRate: 85, bloodPressure: '130/85', respiratoryRate: 20, temperature: 99.1, bloodType: 'A+' },
    // más registros posibles...
  ];

  constructor() { }

  getVitalSigns(): VitalSign[] {
    return this.vitalSigns;
  }

  //Devuelve los datos del paciente
  getPatientById(id: number): VitalSign | undefined {
    return this.vitalSigns.find(sign => sign.id === id);
  }

  

}


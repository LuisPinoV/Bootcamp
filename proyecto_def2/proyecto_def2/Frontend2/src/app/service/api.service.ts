import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = 'https://localhost:5101';  // Cambia a HTTP si no estás usando HTTPS

  constructor(private http: HttpClient) { }

  public getData(): Observable<any> {
    return this.http.get<any>(this.urlApi);
  }

  // Método para obtener los datos de los grupos de edad

  // Método para obtener datos simulados para el gráfico de torta
  public getAgeGroupCounts(): Observable<any> {
    const simulatedData = {
      "bebes": 23,
      "niños": 45,
      "jovenes": 67,
      "adultos": 89,
      "ancianos": 25
    };
    
    return of(simulatedData);
  }


  /*

  POSIBLE FUNCION
  public getAgeGroupCounts(): Observable<any> {
    return this.http.get<any>(`${this.urlApi}/home/countAgeGroups`);
  }
  */  
}



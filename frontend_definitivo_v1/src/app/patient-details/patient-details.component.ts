import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { VitalSignsService, VitalSign } from '../services/vital-signs.service';



@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.css']
})
export class PatientDetailsComponent implements OnInit {
  editForm: FormGroup;
  patientId: number = 0;  // O un valor por defecto que considere apropiado
  chartOptions: any;  // Agregar para configuración del gráfico
  patientData: VitalSign | undefined;  // Agregando esta línea


  constructor(
    private route: ActivatedRoute,
    private vitalSignsService: VitalSignsService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.editForm = this.fb.group({
      fullName: [''],
      age: [''],
      bloodType: [''],
      medicalHistory: ['']
    });
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.patientData = this.vitalSignsService.getPatientById(id);
      if (this.patientData) {
        this.editForm.patchValue(this.patientData);
      } else {
        console.error("No patient data available for ID:", id);
      }
    });
  }

  loadPatientDetails(id: number): void {
    let patient = this.vitalSignsService.getPatientById(id);
    console.log("Loaded patient details:", this.patientData);
    if (this.patientData) {
        this.editForm.patchValue(this.patientData);
    } else {
        console.error("No patient data avaible for ID:", id);
    }
  }

  setupChart(patient: VitalSign): void {
    this.chartOptions = {
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: "Signos Vitales del Paciente"
      },
      axisX: {
        title: "Mediciones"
      },
      axisY: {
        title: "Valores",
        includeZero: true
      },
      data: [
        {
          type: "column", // Cambiado a 'column' para mejor visualización de valores individuales
          name: "Frecuencia Cardíaca",
          showInLegend: true,
          dataPoints: [
            { label: "Frecuencia Cardíaca", y: patient.heartRate }
          ]
        },
        {
          type: "column",
          name: "Presión Arterial Sistólica",
          showInLegend: true,
          dataPoints: [
            { label: "Presión Arterial", y: parseInt(patient.bloodPressure.split('/')[0]) } // Sistólica
          ]
        },
        {
          type: "column",
          name: "Presión Arterial Diastólica",
          showInLegend: true,
          dataPoints: [
            { label: "Presión Arterial", y: parseInt(patient.bloodPressure.split('/')[1]) } // Diastólica
          ]
        },
        {
          type: "column",
          name: "Temperatura",
          showInLegend: true,
          dataPoints: [
            { label: "Temperatura", y: patient.temperature }
          ]
        }
      ]
    };
  }

  save(): void {
    console.log('Updated values:', this.editForm.value);
    this.router.navigate(['/vitalux']);  // Navega de regreso a la lista
  }
}



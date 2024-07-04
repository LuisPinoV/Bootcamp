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
  chartOptions: any;  // Configuración del gráfico
  patientData: VitalSign | undefined;

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
        // Cargar historial médico desde localStorage si está disponible
        const medicalHistory = localStorage.getItem(`medicalHistory-${id}`);
        if (medicalHistory) {
          this.editForm.get('medicalHistory')?.setValue(medicalHistory);
        }
      } else {
        console.error("No patient data available for ID:", id);
      }
    });
  }

  save(): void {
    const id = this.patientData?.id || 0;
    console.log('Updated values:', this.editForm.value);
    // Guardar historial médico en localStorage
    localStorage.setItem(`medicalHistory-${id}`, this.editForm.value.medicalHistory);
    this.router.navigate(['/vitalux']);  // Navegar de regreso a la lista
    console.log('Changes saved locally');
  }
}




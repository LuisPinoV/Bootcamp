import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { VitalSignsService, VitalSign } from '../../services/vital-signs.service';

@Component({
  selector: 'app-vita-lux',
  templateUrl: './vita-lux.component.html',
  styleUrls: ['./vita-lux.component.css']
})
export class VitaLuxComponent implements OnInit {
  vitalSigns: VitalSign[] = [];

  constructor(private router: Router, private vitalSignsService: VitalSignsService) {}

  ngOnInit(): void {
    this.vitalSigns = this.vitalSignsService.getVitalSigns();
    console.log("Vital signs loaded:", this.vitalSigns);
}

  onRowClick(id: number): void {
    console.log("Navigating to details of patient with id:", id);
    this.router.navigate(['/patient-details', id]);  // Navega a la página de detalles
  }

}


  /*
  SEGUNDA OPCIÖN

  onRowClick(id: number): void {
  window.open('/patient-details/' + id, '_blank');
  } 
}
  
  */



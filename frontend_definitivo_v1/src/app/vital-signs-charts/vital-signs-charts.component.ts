// En el archivo vital-signs-charts.component.ts
import { Component, OnInit, Input } from '@angular/core';
import { Chart, registerables } from 'chart.js';
Chart.register(...registerables);

@Component({
  selector: 'app-vital-signs-charts',
  templateUrl: './vital-signs-charts.component.html',
  styleUrls: ['./vital-signs-charts.component.css']
})
export class VitalSignsChartsComponent implements OnInit {
  @Input() signsData: any; // Este input tomará los datos del paciente para los gráficos
  chart!: Chart;

  ngOnInit(): void {
    this.setupChart();
  }

  setupChart() {
    const canvas = document.getElementById('vitalChart') as HTMLCanvasElement;
    if (!canvas) {
      console.error("Canvas element not found!");
      return;
    }
    const ctx = canvas.getContext('2d');
    if (!ctx) {
      console.error("Failed to get canvas context");
      return;
    }
  
    this.chart = new Chart(ctx, {
      type: 'line',
      data: {
        labels: this.signsData.timeStamps,  // Asegúrate de que estos datos están definidos
        datasets: [{
          label: 'Heart Rate',
          data: this.signsData.heartRates,
          borderColor: 'rgb(255, 99, 132)',
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
}



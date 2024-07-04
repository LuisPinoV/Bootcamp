import { Component, OnInit, Input } from '@angular/core';
import { Chart, registerables } from 'chart.js';

Chart.register(...registerables);

@Component({
  selector: 'app-vital-signs-charts',
  templateUrl: './vital-signs-charts.component.html',
  styleUrls: ['./vital-signs-charts.component.css']
})
export class VitalSignsChartsComponent implements OnInit {
  @Input() signsData: any; // Asegúrate de que signsData contiene todos los datos necesarios

  ngOnInit(): void {
    this.setupCharts();
  }

  setupCharts() {
    if (this.signsData) {
      this.createChart('heartRateChart', 'Heart Rate', this.signsData.heartRates, 'rgb(255, 99, 132)');
      this.createChart('bloodPressureChart', 'Blood Pressure', this.signsData.bloodPressures, 'rgb(54, 162, 235)');
      this.createChart('temperatureChart', 'Temperature', this.signsData.temperatures, 'rgb(255, 206, 86)');
      this.createChart('respiratoryRateChart', 'Respiratory Rate', this.signsData.respiratoryRates, 'rgb(75, 192, 192)');
    }
  }

  createChart(chartId: string, label: string, data: number[], borderColor: string) {
    const ctx = (document.getElementById(chartId) as HTMLCanvasElement).getContext('2d');
    if (ctx) {
      new Chart(ctx, {
        type: 'line',
        data: {
          labels: this.signsData.timeStamps,
          datasets: [{
            label: label,
            data: data,
            borderColor: borderColor,
            borderWidth: 2
          }]
        },
        options: {
          responsive: true,
          scales: {
            y: {
              beginAtZero: false
            }
          }
        }
      });
    }
  }
}




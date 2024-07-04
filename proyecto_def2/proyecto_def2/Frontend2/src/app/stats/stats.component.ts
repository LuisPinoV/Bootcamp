import { Component, OnInit } from '@angular/core';
import { ApiService } from '../service/api.service';
import { Chart, ChartConfiguration, ChartTypeRegistry } from 'chart.js';
import { Router } from '@angular/router';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  chart!: Chart;

  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.apiService.getAgeGroupCounts().subscribe({
      next: (data) => this.setupChart(data),
      error: (error) => console.error('Error fetching count data:', error)
    });
  }

  setupChart(data: any): void {
    const canvas = document.getElementById('statsChart') as HTMLCanvasElement;
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    if (!ctx) return;
  
    this.chart = new Chart(ctx, {
      type: 'polarArea',
      data: {
        labels: ['Bebés', 'Niños', 'Jóvenes', 'Adultos', 'Ancianos'],
        datasets: [{
          data: [
            data.bebes,
            data.niños,
            data.jovenes,
            data.adultos,
            data.ancianos
          ],
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(75, 192, 192)',
            'rgb(255, 205, 86)',
            'rgb(201, 203, 207)',
            'rgb(54, 162, 235)'
          ]
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: true,
        aspectRatio: 2.0,  // Más pequeño para ajustar el tamaño del gráfico
        plugins: {
          legend: {
            position: 'top',
          },
          tooltip: {
            mode: 'index',
            intersect: false,
          },
          title: {  // Configuración del título
            display: true,
            text: 'Número de personas por rango etario',
            padding: {
              top: 10,
              bottom: 30
            },
            font: {
              size: 18
            }
          }
        }
      }
    } as ChartConfiguration<keyof ChartTypeRegistry, (number | [number, number] | null)[], unknown>);
  }
  
  goBack(): void {
    this.router.navigate(['/vitalux']); // Usa el Router para navegar
  }

}




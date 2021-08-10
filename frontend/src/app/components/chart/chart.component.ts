import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarDataService } from '../../services/car-data.service';
import { ChartData } from '../../ChartData';
import { Chart, registerables } from 'node_modules/chart.js'

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
  minutes!: number;
  chartData!: ChartData;
  chart!: String;
  powerUsageChart!: Chart;
  powerUsageAvgChart!: Chart;
  coveredDistanceChart!: Chart;
    
  constructor(
    private route: ActivatedRoute,
    private carDataService: CarDataService
  )
  {
    Chart.register(...registerables);
    this.route.paramMap.subscribe(params =>
    {
      let minutes: number = Number(params.get('minutes'));
      if (isNaN(minutes) || minutes<=0)
      {
        minutes = 1;
      }
      this.minutes = minutes;
      this.updateChart();
    });
  }

  ngOnInit(): void
  {
    
  }
  
  updateChart(): void {
    this.carDataService.getChartData(this.minutes).subscribe((res) =>
    {
      this.chartData = res;
      this.chart = JSON.stringify(res);
      this.destroyCharts();
      const labels = [...Array(this.minutes)].map((_, index) => index + 1);
      
      const powerUsageData = {
        labels: labels,
        datasets: [{
          label: 'Power usage for every minute in kW',
          backgroundColor: 'rgb(255, 200, 132)',
          borderColor: 'rgb(255, 200, 132)',
          data: res.powerUsage,
        }]
      };
      this.createPowerUsageChart(powerUsageData);
      
      const powerUsageAvgData = {
        labels: labels,
        datasets: [{
          label: 'Average power usage for every minute in kW/km',
          backgroundColor: 'rgb(255, 99, 132)',
          borderColor: 'rgb(255, 99, 132)',
          data: res.powerUsageAvg,
        }]
      };
      this.createPowerUsageAvgDataChart(powerUsageAvgData);

      const coveredDistanceData = {
        labels: labels,
        datasets: [{
          label: 'Covered distance for every minut in km',
          backgroundColor: 'rgb(0, 99, 132)',
          borderColor: 'rgb(0, 99, 132)',
          data: res.powerUsage,
        }]
      };
      this.createCoveredDistanceChart(coveredDistanceData);
    });
  }

  createPowerUsageChart(data: any): void
  {
    this.powerUsageChart = new Chart(
      'powerUsageChart',
      {
        type: 'line',
        data,
        options: {}
      }
    );
  }

  createPowerUsageAvgDataChart(data: any): void
  {
    this.powerUsageAvgChart = new Chart(
      'powerUsageAvgChart',
      {
        type: 'line',
        data,
        options: {}
      }
    );
  }

  createCoveredDistanceChart(data: any): void {
    this.coveredDistanceChart = new Chart(
      'coveredDistanceChart',
      {
        type: 'line',
        data,
        options: {}
      }
    );
  }

  destroyCharts(): void {
    if (this.powerUsageChart) this.powerUsageChart.destroy();
    if (this.powerUsageAvgChart) this.powerUsageAvgChart.destroy()
    if (this.coveredDistanceChart) this.coveredDistanceChart.destroy();
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarDataService } from '../../services/car-data.service';
import { ChartData } from '../../ChartData';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
  minutes!: number;
  chartData!: ChartData;
  chart!: String;
    
  constructor(
    private route: ActivatedRoute,
    private carDataService: CarDataService
  )
  {
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

  ngOnInit(): void { }
  
  updateChart(): void {
    this.carDataService.getChartData(this.minutes).subscribe((data) =>
    {
      this.chartData = data;
      this.chart = JSON.stringify(data);
    });
  }
}

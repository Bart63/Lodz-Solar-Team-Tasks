import { Component, OnInit } from '@angular/core';
import { CarDataService } from '../../services/car-data.service';
import { CarSummary } from '../../CarSummary';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  summary!: CarSummary;
  table!: String;

  constructor(
    private carDataService: CarDataService
  ) { }

  ngOnInit(): void {
    this.carDataService.getSummary().subscribe((data) =>
    {
      this.summary = data;
      this.table = JSON.stringify(data);
    });
  }
}

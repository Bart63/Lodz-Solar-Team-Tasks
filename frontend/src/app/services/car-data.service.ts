import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CarSummary } from '../CarSummary';
import { ChartData } from '../ChartData';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarDataService {
  private apiUrl = 'http://localhost:5000/'

  constructor(
    private http: HttpClient
  ) { }

  getSummary(): Observable<CarSummary> {
    return this.http.get<CarSummary>(this.apiUrl + 'api/car');
  }

  getChartData(minutes: number): Observable<ChartData> {
    return this.http.get<ChartData>(this.apiUrl + `api/summary?time=${minutes}`)
  }
}

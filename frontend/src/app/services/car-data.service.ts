import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CarSummary } from '../CarSummary';
import { Observable, of } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CarDataService {
  private apiUrl = 'http://localhost:5000/'

  constructor(
    private http: HttpClient
  ) { }

  getSummary(): Observable<CarSummary> {
    return this.http.get<CarSummary>(this.apiUrl + 'api/car', httpOptions);
  }
}

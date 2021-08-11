import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { CarDataService } from './car-data.service';

describe('CarDataService', () => {
  let service: CarDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(CarDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('summary should be truthy', () =>
  {
    expect(service.getSummary()).toBeTruthy();
  });

  it('chart data should be truthy', () =>
  {
    expect(service.getChartData(0)).toBeTruthy();
  });
});


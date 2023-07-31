import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../enviroments/enviroment';

interface Tariff {
  tariffName: string;
  annualCosts: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  consumption: number = 0;
  tariffs: Tariff[] = [];
  errorMessage: string = '';

  constructor(private http: HttpClient) {}

  isNumber(value: any): boolean {
    const maxValue = 2147483647; // maximum value for an integer
    const minValue = 0;
    return !isNaN(value) && typeof value === 'number' && value <= maxValue && value >= minValue;
  }

  getTariffs(): void {
    if (!this.isNumber(this.consumption)) {
      this.errorMessage = "Please input a valid integer for consumption.";
      return;
    }
    this.http.post<Tariff[]>(environment.apiUrl + '/tariff/comparison', this.consumption)
      .subscribe(response => {
        this.tariffs = response;
        this.errorMessage = '';
      }, error => {
        console.error(error);
        this.errorMessage = error.error || 'An unknown error occurred';
      });
  }
}

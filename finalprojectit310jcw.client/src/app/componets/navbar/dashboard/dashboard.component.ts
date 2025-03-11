// dashboard.component.ts - Angular Dashboard Component
import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../../services/weather.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  weatherData: any[] = [];
  isLoading: boolean = false;
  errorMessage: string | null = null;

  constructor(private weatherService: WeatherService) { }

  ngOnInit() {
    this.loadWeatherData();
  }

  loadWeatherData() {
    this.isLoading = true;
    this.errorMessage = null;
    this.weatherService.getWeather().subscribe(
      data => {
        this.weatherData = data;
        this.isLoading = false;
      },
      error => {
        this.isLoading = false;
        this.errorMessage = 'Failed to load weather data. Please try again later.';
      }
    );
  }
}

// edit-weather.component.ts - Edit Weather Modal Component
import { Component, Input } from '@angular/core';
import { WeatherService } from '../../services/weather.service';

@Component({
  selector: 'app-edit-weather',
  templateUrl: './edit-weather.component.html',
  styleUrls: ['./edit-weather.component.css']
})
export class EditWeatherComponent {
  @Input() weather: any;
  isLoading: boolean = false;

  constructor(private weatherService: WeatherService) { }

  saveChanges() {
    this.isLoading = true;
    this.weatherService.updateWeather(this.weather).subscribe(
      () => {
        this.isLoading = false;
        alert('Weather updated successfully!');
        window.location.reload();
      },
      error => {
        this.isLoading = false;
        alert('Failed to update weather data');
      }
    );
  }
}

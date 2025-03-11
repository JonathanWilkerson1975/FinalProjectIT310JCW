// weather.service.ts - Angular Service for Weather API
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class WeatherService {
  private apiUrl = 'https://localhost:5213/api/weatherforecast';

  constructor(private http: HttpClient) { }

  getWeather(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  updateWeather(weather: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${weather.date}`, weather);
  }

  deleteWeather(date: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${date}`);
  }
}

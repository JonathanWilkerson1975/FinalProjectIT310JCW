// app.module.ts - Main Angular Module
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthComponent } from './components/auth/auth.component';
import { EditWeatherComponent } from './components/edit-weather/edit-weather.component';
import { ToastComponent } from './components/toast/toast.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { AuthService } from './services/auth.service';
import { WeatherService } from './services/weather.service';
import { AuthGuard } from './guards/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DashboardComponent,
    AuthComponent,
    EditWeatherComponent,
    ToastComponent,
    LoadingSpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AuthService, WeatherService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

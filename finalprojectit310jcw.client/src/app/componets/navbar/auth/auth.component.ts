
// auth.component.ts - Angular Authentication Component
import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/components/navbar/auth/toast/services/auth.service';
import { ToastComponent } from 'src/app/components/navbar/auth/toast/toast.component';
@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent {
  @ViewChild(ToastComponent) toast!: ToastComponent;

  loginData = { email: '', password: '' };
  signupData = { name: '', email: '', password: '' };

  constructor(private authService: AuthService, private router: Router) { }

  onLogin() {
    this.authService.login(this.loginData.email, this.loginData.password).subscribe(
        (      response: { token: string; }) => {
        localStorage.setItem('token', response.token);
        this.toast.showToast('Login Successful!', 'success');
        this.router.navigate(['/dashboard']);
      },
        (      error: any) => this.toast.showToast('Login Failed', 'error')
    );
  }

  onSignup() {
    this.authService.signup(this.signupData.name, this.signupData.email, this.signupData.password).subscribe(
        (      response: any) => {
        this.toast.showToast('Signup Successful! Please login.', 'success');
      },
        (      error: any) => this.toast.showToast('Signup Failed', 'error')
    );
  }
}

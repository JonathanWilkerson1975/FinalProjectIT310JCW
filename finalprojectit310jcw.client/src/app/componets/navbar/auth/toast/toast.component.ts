// toast.component.ts - Angular Toast Notification Component
import { Component } from '@angular/core';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css']
})
export class ToastComponent {
  message: string = '';
  type: string = '';
  isVisible: boolean = false;

  showToast(message: string, type: string) {
    this.message = message;
    this.type = type;
    this.isVisible = true;
    setTimeout(() => this.isVisible = false, 3000);
  }
}

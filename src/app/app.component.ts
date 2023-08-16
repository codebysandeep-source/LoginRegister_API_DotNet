import { Component } from '@angular/core';

import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Login';

  constructor(private router:Router, private AuthService:AuthService) { 
    this.isLoggedIn();
  }
  isLoggedIn() { return this.AuthService.isLoggedIn() };

  logout(): void{
    this.AuthService.logout();
    this.isLoggedIn();
    this.router.navigate(['/']);
  }
  
}

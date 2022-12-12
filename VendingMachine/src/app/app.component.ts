import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'VendingMachine';

  constructor(private authService: AuthService, private router: Router){ }

  isUserAuthenticated() {
    return this.authService.isUserAuthenticated();
  }

  public logOut = () => {
    this.authService.logOut().subscribe(() => {
      localStorage.removeItem("jwt");
      this.router.navigate(["login"]);
    })
  }
}
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  roles!: Array<string>;
  constructor(private authService: AuthService){}

  ngOnInit(): void {
    this.fetchUserRoles()
  }

  fetchUserRoles() {
    this.authService.getUserRoles().subscribe({
      next: data => {
        this.roles = data;
      }
    })
  }
}

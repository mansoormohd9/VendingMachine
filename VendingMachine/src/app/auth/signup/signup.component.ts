import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  signupForm!: FormGroup;

  constructor(private toastr: ToastrService, private authService: AuthService, private router: Router){}

  ngOnInit(): void {
    this.signupForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      role: new FormControl('Buyer')
    })
  }

  onSubmit(form: FormGroup) {
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }

    this.authService.signUp(form.value)
    .subscribe((response) => {
      const token = response.token;
      localStorage.setItem("jwt", token);
      this.router.navigate(["/home"]);
    }, err => {
      this.toastr.error(err);
    })
  }
}

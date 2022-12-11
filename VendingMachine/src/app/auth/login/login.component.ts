import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private toastr: ToastrService, private authService: AuthService, private router: Router){}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required)
    })
  }

  onSubmit(form: FormGroup) {
    console.log('Email', form.value.email);
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }

    this.authService.login(form.value)
    .subscribe((response) => {
      const token = response.token;
      localStorage.setItem("jwt", token);
      this.router.navigate(["/home"]);
    }, err => {
      this.toastr.error(err);
    })
  }

  get loginFormControls() { return this.loginForm.controls }
}

import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', Validators.required),
      role: new FormControl('Buyer', Validators.required)
    })
  }

  onSubmit(form: FormGroup) {
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }

    this.authService.signUp(form.value)
    .subscribe((response) => {
      localStorage.setItem("jwt", response);
      this.router.navigate(["/home"]);
    }, err => {
      this.toastr.error(err);
    })
  }

  get signUpFormControls() { return this.signupForm.controls }
}

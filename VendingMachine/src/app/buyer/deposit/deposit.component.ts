import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BuyerService } from '../buyer.service';
import { DepositDto } from '../models/Buyer';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit{
  depositForm!: FormGroup;

  constructor(private toastr: ToastrService, private buyerService: BuyerService, private router: Router){}

  ngOnInit(): void {
    this.depositForm = new FormGroup({
      deposit: new FormControl('', [Validators.required]),
      quantity: new FormControl('', Validators.required)
    })
  }

  onSubmit(form: FormGroup) {
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }
    const deposits = Array<DepositDto>().fill(form.value);
    this.buyerService.deposit(deposits)
    .subscribe({
      next: data => {
        this.toastr.success("Deposit success");
        this.router.navigate(["/buyer/home"]);
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }

  get depositFormControls() { return this.depositForm.controls }
}

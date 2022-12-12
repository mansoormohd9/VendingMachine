import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BuyerService } from '../buyer.service';
import { DepositDto } from '../models/Buyer';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent {
  buyForm!: FormGroup;

  constructor(private toastr: ToastrService, private buyerService: BuyerService, private router: Router){}

  ngOnInit(): void {
    this.buyForm = new FormGroup({
      deposit: new FormControl('', [Validators.required]),
      quantity: new FormControl('', Validators.required)
    })
  }

  onSubmit(form: FormGroup) {
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }
    let deposits = Array<DepositDto>();
    deposits.push(form.value);
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

  get buyFormControls() { return this.buyForm.controls }
}

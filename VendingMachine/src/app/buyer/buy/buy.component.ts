import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductDto } from 'src/app/seller/models/Seller';
import { SellerService } from 'src/app/seller/seller.service';
import { BuyerService } from '../buyer.service';
import { DepositDto } from '../models/Buyer';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent {
  buyForm!: FormGroup;
  products!: Array<ProductDto>;

  constructor(private toastr: ToastrService, private buyerService: BuyerService, private router: Router, private sellerService: SellerService){}

  ngOnInit(): void {
    this.fetchProducts()
    this.buyForm = new FormGroup({
      productId: new FormControl('', [Validators.required]),
      amount: new FormControl('', Validators.required)
    })
  }

  fetchProducts() {
    this.sellerService.viewAllProducts()
    .subscribe({
      next: data => {
        this.products = data;
      },
      error: error => {
        console.error('There was an error!', error);
      }
    })
  }

  onSubmit(form: FormGroup) {
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }
    this.buyerService.buy(form.value)
    .subscribe({
      next: data => {
        this.toastr.success("Buy success");
        this.router.navigate(["/buyer/home"]);
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }

  get buyFormControls() { return this.buyForm.controls }
}

import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductDto } from '../models/Seller';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-add-products',
  templateUrl: './add-products.component.html',
  styleUrls: ['./add-products.component.css']
})
export class AddProductsComponent {
  productForm!: FormGroup;

  constructor(private toastr: ToastrService, private sellerService: SellerService, private router: Router){}

  ngOnInit(): void {
    this.productForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      amountAvailable: new FormControl('', Validators.required),
      cost: new FormControl('', Validators.required),
    })
  }

  onSubmit(form: FormGroup) {
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }
    this.sellerService.addProduct(form.value)
    .subscribe({
      next: data => {
        this.toastr.success("Add product success");
        this.router.navigate(["/seller/home"]);
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }

  get productFormControls() { return this.productForm.controls }
}

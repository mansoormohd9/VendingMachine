import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductDto, ProductSaveDto } from '../models/Seller';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-add-products',
  templateUrl: './add-products.component.html',
  styleUrls: ['./add-products.component.css']
})
export class AddProductsComponent {
  productForm!: FormGroup;
  productId!: number;
  productData: ProductDto = {
    name: '',
    cost: 0,
    amountAvailable: 0,
    id: 0
  }

  constructor(private toastr: ToastrService, private sellerService: SellerService, private router: Router, private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.productId = parseInt(params.get('productId') ?? "");
      if(this.productId && this.productId > 0) {
        this.sellerService.getProduct(this.productId)
        .subscribe({
          next: data => {
            this.productData = data
            this.productForm = new FormGroup({
              name: new FormControl(this.productData.name, [Validators.required]),
              amountAvailable: new FormControl(this.productData.amountAvailable, Validators.required),
              cost: new FormControl(this.productData.cost, Validators.required),
            })
          },
          error: error => {
            console.error('There was an error!', error);
          }
        })
      } else {
        this.productForm = new FormGroup({
          name: new FormControl('', [Validators.required]),
          amountAvailable: new FormControl('', Validators.required),
          cost: new FormControl('', Validators.required),
        })
      }
    });
    
  }

  onSubmit(form: FormGroup) {
    if(!form.valid) {
      this.toastr.error("Found errors in form");
      return;
    }
    if(this.productId && this.productId > 0) {
      this.updateProduct(form.value);
    } else {
      this.addProduct(form.value);
    }
  }

  addProduct(product: ProductSaveDto) {
    this.sellerService.addProduct(product)
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

  updateProduct(product: ProductSaveDto) {
    this.sellerService.updateProduct(product, this.productId)
    .subscribe({
      next: data => {
        this.toastr.success("Update product success");
        this.router.navigate(["/seller/home"]);
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }

  get productFormControls() { return this.productForm.controls }
}

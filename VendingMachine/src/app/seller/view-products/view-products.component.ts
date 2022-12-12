import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductDto } from '../models/Seller';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent {
  products!: Array<ProductDto>;
  constructor(private sellerService: SellerService, private toastr: ToastrService, private router: Router){ }

  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts() {
    this.sellerService.viewProducts()
    .subscribe({
      next: data => {
        this.products = data;
      },
      error: error => {
        console.error('There was an error!', error);
      }
    })
  }

  deleteProduct = (e:Event, id: number) => {
    e.preventDefault();
    this.sellerService.deleteProduct(id).subscribe({
      next: data => {
        this.toastr.success("Delete Success");
        this.products = this.products?.filter(x => x.id != id);
      },
      error: error => {
        console.error('There was an error!', error);
      }
    })
  }

  editProduct = (e:Event, id: number) => {
    e.preventDefault();
    this.router.navigate(["/seller/add/" + id]);
  }
}

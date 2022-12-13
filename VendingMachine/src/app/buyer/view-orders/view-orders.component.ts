import { Component } from '@angular/core';
import { BuyerService } from '../buyer.service';
import { UserBuyDto } from '../models/Buyer';

@Component({
  selector: 'app-view-orders',
  templateUrl: './view-orders.component.html',
  styleUrls: ['./view-orders.component.css']
})
export class ViewOrdersComponent {
  userOrders!: Array<UserBuyDto>;
  constructor(private buyerService: BuyerService){ }

  ngOnInit(): void {
    this.fetchOrders();
  }

  fetchOrders() {
    this.buyerService.getUserOrders()
    .subscribe({
      next: data => {
        this.userOrders = data;
      },
      error: error => {
        console.error('There was an error!', error);
      }
    })
  }
}

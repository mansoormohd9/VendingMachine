import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BuyerService } from '../buyer.service';
import { DepositDto } from '../models/Buyer';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
deposits!: Array<DepositDto>;

  constructor(private buyerService: BuyerService, private toastr: ToastrService){ }

  ngOnInit(): void {
    this.fetchDeposits();
  }

  fetchDeposits() {
    this.buyerService.getDeposits()
    .subscribe({
      next: data => {
        this.deposits = data;
      },
      error: error => {
        console.error('There was an error!', error);
      }
    })
  }
}

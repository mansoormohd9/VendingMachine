import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BuyDto, DepositDto } from './models/Buyer';

@Injectable({
  providedIn: 'root'
})
export class BuyerService {
  apiBase = "api/deposits";
  buyApiBase = "api/buy";
  httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'})};
  constructor(private http: HttpClient) { }

  deposit(deposit: Array<DepositDto>): Observable<any> {
    return this.http.post(this.apiBase, deposit, this.httpHeaders);
  }

  buy(buyDto: BuyDto): Observable<any> {
    return this.http.post(this.buyApiBase, buyDto, this.httpHeaders);
  }

  getDeposits(): Observable<Array<DepositDto>> {
    return this.http.get<Array<DepositDto>>(this.apiBase, this.httpHeaders);
  }

  resetDeposit(): Observable<any> {
    return this.http.post(this.apiBase + "/reset", null, this.httpHeaders);
  }
}

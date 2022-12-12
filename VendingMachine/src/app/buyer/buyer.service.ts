import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepositDto } from './models/Buyer';

@Injectable({
  providedIn: 'root'
})
export class BuyerService {
  apiBase = "api/deposits";
  httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'})};
  constructor(private http: HttpClient) { }

  deposit(deposit: Array<DepositDto>): Observable<any> {
    return this.http.post(this.apiBase, deposit, this.httpHeaders);
  }
}

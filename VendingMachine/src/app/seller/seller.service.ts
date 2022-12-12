import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDto, ProductSaveDto } from './models/Seller';

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  apiBase = "api/products/";
  httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
  constructor(private http: HttpClient) { }

  addProduct(product: ProductSaveDto): Observable<any> {
    return this.http.post(this.apiBase, product, this.httpHeaders);
  }

  viewProducts(): Observable<Array<ProductDto>> {
    return this.http.get<Array<ProductDto>>(this.apiBase);
  }

  getProduct(productId: number): Observable<ProductDto> {
    return this.http.get<ProductDto>(this.apiBase + productId);
  }

  viewAllProducts(): Observable<Array<ProductDto>> {
    return this.http.get<Array<ProductDto>>(this.apiBase + "all");
  }

  updateProduct(product: ProductSaveDto, id: number): Observable<any> {
    return this.http.put(this.apiBase + id, product, this.httpHeaders);
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete(this.apiBase + id);
  }
}

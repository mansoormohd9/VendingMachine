import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginDto } from '../models/Auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiBase = "api/account/";
  httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
  constructor(private http: HttpClient) { }

  login(credentials: LoginDto): Observable<any> {
    return this.http.post(this.apiBase+ "/login", credentials, this.httpHeaders);
  }
}

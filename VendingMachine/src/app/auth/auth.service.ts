import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { LoginDto, SignupDto } from '../models/Auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiBase = "api/account/";
  httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  login(credentials: LoginDto): Observable<any> {
    return this.http.post(this.apiBase+ "/login", credentials, this.httpHeaders);
  }

  signUp(signUpDto: SignupDto): Observable<any> {
    return this.http.post(this.apiBase+ "/signup", signUpDto, this.httpHeaders);
  }

  logOut(): Observable<any> {
    return this.http.get(this.apiBase + "/logOut");
  }

  getUserRole(): Observable<any> {
    return this.http.get(this.apiBase + "/getUserRole");
  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
}

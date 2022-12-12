import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { catchError, Observable } from 'rxjs';
import { HelperService } from '../helpers/helper.service';
import { LoginDto, SignupDto } from '../models/Auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiBase = "api/account";
  usersApiBase = "api/users";
  httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}), responseType: 'text' as any };
  constructor(private http: HttpClient, private jwtHelper: JwtHelperService, private helperService: HelperService) { }

  login(credentials: LoginDto): Observable<any> {
    return this.http.post(this.apiBase+ "/login", credentials, this.httpHeaders);
  }

  signUp(signUpDto: SignupDto): Observable<string> {
    return this.http.post<string>(this.apiBase+ "/signup", signUpDto, this.httpHeaders);
  }

  logOut(): Observable<any> {
    return this.http.get(this.apiBase + "/logOut");
  }

  getUserRoles(): Observable<any> {
    return this.http.get(this.usersApiBase + "/user-roles");
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

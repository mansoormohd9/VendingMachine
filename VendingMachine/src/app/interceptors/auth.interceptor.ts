import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { HelperService } from '../helpers/helper.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private helperService: HelperService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = localStorage.getItem("jwt");

    if (!token) {
      return next.handle(request).pipe(catchError(this.helperService.handleError));
    }

    const clonedRequest = request.clone({
      headers: request.headers.set('Authorization', `Bearer ${token}`),
    });

    return next.handle(clonedRequest).pipe(catchError(this.helperService.handleError));
  }
}

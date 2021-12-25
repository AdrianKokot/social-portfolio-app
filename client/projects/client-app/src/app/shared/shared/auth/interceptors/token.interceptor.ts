import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { map, Observable, switchMap, take } from 'rxjs';
import { AuthService } from "../auth.service";

@Injectable({providedIn: 'root'})
export class TokenInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.auth.token$
      .pipe(
        take(1),
        map(token => {

          return token
            ? request.clone({
              setHeaders: {
                Authorization: `Bearer ${token}`
              }
            })
            : request;

        }),
        switchMap(request => next.handle(request))
      );
  }
}

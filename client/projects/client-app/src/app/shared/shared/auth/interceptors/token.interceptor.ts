import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { map, Observable, switchMap, take } from 'rxjs';
import { AuthService } from "../auth.service";

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.auth.token$.pipe(
      take(1),
      map(token => {
        if (token) {
          request.headers.append('Authorization', `Bearer ${token}`);
        }

        return request;
      }),
      switchMap(request => next.handle(request))
    );
  }
}

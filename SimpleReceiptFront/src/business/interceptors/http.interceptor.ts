import { ErrorHelper } from './../helpers/error.helper';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { tap } from 'rxjs/operators';

@Injectable()
export class HttpInterceptor implements HttpInterceptor {

  constructor(public errorHandler: ErrorHelper) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const baseUrl = 'https://localhost:44317/';
    // onst baseUrl = '';

    req = req.clone({
      url: baseUrl + req.url
    });

    return next.handle(req)
      .pipe(
        tap(
          (event: HttpEvent<any>) => { },
          (err: any) => {
            if (err instanceof HttpErrorResponse) {
              this.errorHandler.handleError(err);
            }
          }
        )
      );
  }
}


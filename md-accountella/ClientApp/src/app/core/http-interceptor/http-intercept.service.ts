// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';

// import {
//   HttpInterceptor,
//   HttpRequest,
//   HttpHeaders,
//   HttpEvent,
//   HttpHandler} from '@angular/common/http';

// import { catchError, finalize, map } from 'rxjs/operators';



// @Injectable()
// export class HttpInterceptorService implements HttpInterceptor {

//   constructor() { }

//   intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     const headers = new HttpHeaders()
//       .set('Accept-Language', 'en')
//       .set('Content-Type', 'application/json');
//     request = request.clone({ headers: headers, withCredentials: true });
//     return next.handle(request)
//       .pipe(map(event => {
//         return event;
//       }),
//         catchError(error => {
//           return this.errorHandler.handleError(error);
//         }),
//         finalize(() => {
//           this.spinner.show(false);
//         })
//       );
//   }
// }

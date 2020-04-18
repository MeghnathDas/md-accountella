import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpHeaders, HttpEvent } from '@angular/common/http';
import { BlockInteractionService } from '../block-interaction/block-interaction.service';
import { catchError, finalize, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {
    constructor(private blockerserv: BlockInteractionService) {
    }

    intercept(request: HttpRequest<any>, next: HttpHandler) {
        this.blockerserv.start();
        return next.handle(request.clone())
            .pipe(map(event => {
                return event;
            }),
                catchError(error => {
                    return this.handleError(error);
                }),
                finalize(() => {
                    this.blockerserv.stop();
                })
            );
    }

    private handleError(httpError: any): Observable<HttpEvent<any>> {
        let errorMessage = `An error occurred:' ${httpError.status} - ${
            httpError.statusText
            }`;
        if (httpError.error) {
            if (httpError.error.ExceptionMessage) {
                errorMessage = `${errorMessage} - ${httpError.error.ExceptionMessage}`;
            } else {
                console.log(httpError);
                return throwError(httpError);
            }
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }
}

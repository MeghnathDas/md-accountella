import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from 'src/app/app-features/models';
import { environment } from 'src/environments/environment';

@Injectable()
export class AccountMapService {
  accountEndpoint = 'accounts';

  constructor(private httpc: HttpClient) { }

  getCategories(): Observable<Category[]> {
    const url = `${environment.apiHost}/${this.accountEndpoint}/categories`;
    return this.httpc.get<Category[]>(url);
  }
}

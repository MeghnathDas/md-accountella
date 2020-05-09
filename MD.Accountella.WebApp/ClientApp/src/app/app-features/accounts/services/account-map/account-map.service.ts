import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from 'src/app/app-features/models';
import { environment } from 'src/environments/environment';

@Injectable()
export class AccountMapService {
  accountEndpoint = `${environment.apiHost}/account-map`;

  constructor(private httpc: HttpClient) { }

  getCategoryMap(): Observable<Category[]> {
    const url = `${this.accountEndpoint}/categories`;
    return this.httpc.get<Category[]>(url);
  }
  getAccountsBySubCategory(categoryId: string): Observable<Account[]> {
    const url = `${this.accountEndpoint}/accounts-by-category/${categoryId}`;
    return this.httpc.get<Account[]>(url);
  }
}

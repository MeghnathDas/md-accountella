import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from 'src/app/app-features/models';
import { environment } from 'src/environments/environment';
import { Acount } from '../../../models/acount.model';

@Injectable()
export class AccountMapService {
  private accountMapEndpoint = `${environment.apiHost}/account-map`;
  private accountTypesEndpoint = `${this.accountMapEndpoint}/account-types`;
  private accountsEndpoint = `${this.accountMapEndpoint}/accounts`;

  constructor(private httpc: HttpClient) { }

  getAccountGroups(): Observable<Category[]> {
    const url = `${this.accountMapEndpoint}/account-groups`;
    return this.httpc.get<Category[]>(url);
  }
  getAccountsByType(accTypeId: string): Observable<Acount[]> {
    const url = `${this.accountMapEndpoint}/accounts-by-type/${accTypeId}`;
    return this.httpc.get<Acount[]>(url);
  }
  getAccountTypes(): Observable<Category[]> {
    const url = `${this.accountMapEndpoint}/account-types`;
    return this.httpc.get<Category[]>(url);
  }
  addAccountType(accTypToAdd: Category): Observable<Category> {
    return this.httpc.post<Category>(this.accountTypesEndpoint, accTypToAdd);
  }
  removeAccountType(accTypeId: string): Observable<any> {
    return this.httpc.delete(`${this.accountTypesEndpoint}/${accTypeId}`);
  }
  addAccount(accToAdd: Acount): Observable<Account> {
    return this.httpc.post<Account>(this.accountsEndpoint, accToAdd);
  }
  updateAccount(accToAlter: Acount): Observable<any> {
    return this.httpc.put<Account>(`${this.accountsEndpoint}/${accToAlter.id}`, accToAlter);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NavNode } from '../../models';
import { environment } from 'src/environments/environment';

@Injectable()
export class NavMenuService {

  constructor(private httpc: HttpClient) { }

  getNavMenus(): Observable<NavNode[]> {
    return this.httpc.get<NavNode[]>(`${environment.apiHost}/nav-nodes`);
  }
}

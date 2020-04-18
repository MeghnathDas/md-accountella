import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NavNode } from 'src/app/models';

@Injectable()
export class NavMenuService {

  constructor(private httpc: HttpClient) { }

  getNavMenus(): Observable<NavNode[]> {
    return this.httpc.get<NavNode[]>('/api/nav-nodes');
  }
}

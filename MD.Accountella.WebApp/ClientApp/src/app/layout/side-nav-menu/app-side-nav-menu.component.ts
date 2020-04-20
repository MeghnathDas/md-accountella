import { Component, OnInit, Input } from '@angular/core';
import { NavNode } from 'src/app/models';

@Component({
  selector: 'app-side-nav-menu',
  templateUrl: './app-side-nav-menu.component.html',
  styleUrls: ['./app-side-nav-menu.component.css']
})
export class SideNavMenuComponent {
  @Input() data: NavNode[] = [];
}


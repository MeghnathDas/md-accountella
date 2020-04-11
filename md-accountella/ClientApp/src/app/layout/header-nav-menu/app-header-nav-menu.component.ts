import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header-nav-menu',
    templateUrl: './app-header-nav-menu.component.html',
    styleUrls: ['./app-header-nav-menu.component.css']
})
export class HeaderNavMenuComponent {
  isExpanded = false;
  appName = 'Accountella';

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}


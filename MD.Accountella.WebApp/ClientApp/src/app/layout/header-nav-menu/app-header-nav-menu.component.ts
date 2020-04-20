import { Component, OnInit, Input } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TitleService } from 'src/app/core/title-service/title.service';

@Component({
  selector: 'app-header-nav-menu',
  templateUrl: './app-header-nav-menu.component.html',
  styleUrls: ['./app-header-nav-menu.component.css']
})
export class HeaderNavMenuComponent {
  isExpanded = false;

  @Input()
  caption = '';

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}


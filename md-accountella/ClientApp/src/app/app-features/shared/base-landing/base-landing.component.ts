import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-base-landing',
  templateUrl: './base-landing.component.html',
  styleUrls: ['./base-landing.component.css']
})
export class BaseLandingComponent implements OnInit {
  @Input()
  caption: string;

  constructor() { }

  ngOnInit(): void {
  }

}

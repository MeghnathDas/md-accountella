import { Component, OnInit } from '@angular/core';
import { TitleService } from '../../core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private titleServ: TitleService) { }

  ngOnInit(): void {
    this.titleServ.updateTitleWithSuffix('Dashboard');
  }

}

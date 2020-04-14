import { Component, OnInit, ChangeDetectorRef, AfterViewChecked } from '@angular/core';
import { CustomClarityIcons } from './shared';
import { Router, NavigationEnd, Event, ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { TitleService } from './core/title-service/title.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterViewChecked {
  appNme: string;
  currentTask: string;

  constructor(private cdr: ChangeDetectorRef,
    private router: Router,
    private titleServ: TitleService,
    private clIcons: CustomClarityIcons) {
    this.appNme = this.titleServ.getBaseTitle();
    this.clIcons.load();

    // this.router.events.subscribe((event: Event) => {
    //   // if (event instanceof NavigationEnd) {
    //   //   let subTitle = event.urlAfterRedirects.split('/').pop();
    //   //   subTitle = subTitle.split('-')
    //   //         .map(w => w[0].toUpperCase() + w.substr(1).toLowerCase())
    //   //         .join(' ');
    //     // this.titleserv.setTitle(this.appNme + ' - ' + subTitle);
    //   }
    // });
    this.titleServ.reset();
  }
  ngAfterViewChecked(): void {
    this.cdr.detectChanges();
  }

  ngOnInit(): void {
    this.titleServ.titleChange().subscribe(dta => {
      if (dta) { this.currentTask = this.titleServ.getSuffix(); }
    });
  }
}


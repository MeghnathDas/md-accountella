import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { Observable, BehaviorSubject } from 'rxjs';

// const APP_TITLE = 'Title';
// const SEPARATOR = ' > ';
export class TitleChangeEventData {
    oldBaseTitle: string;
    oldSuffix: string;
}

@Injectable()
export class TitleService implements OnInit {
    private appTitle: string;
    private suffix: string;
    readonly _changeData = new BehaviorSubject<TitleChangeEventData>(new TitleChangeEventData());

    constructor(
        private router: Router,
        private titleService: Title,
    ) {
        this.appTitle = 'Accountella';
    }

    ngOnInit(): void {
    }

    reset() {
        this.titleService.setTitle(this.appTitle);
    }

    updateTitleWithSuffix(strSuffix: string): void {
        const titleChangeData = Object.assign({}, this._changeData.value);
        titleChangeData.oldBaseTitle = titleChangeData.oldSuffix;
        titleChangeData.oldSuffix = titleChangeData.oldSuffix;

        this.suffix = strSuffix;
        this.titleService.setTitle(this.getTitle());

        this._changeData.next(titleChangeData);
    }

    titleChange(): Observable<TitleChangeEventData> {
        return this._changeData.asObservable();
    }

    getTitle(): string {
        return this.suffix ? this.appTitle + ' - ' + this.suffix : this.appTitle;
    }

    getBaseTitle(): string {
        return this.appTitle;
    }

    getSuffix(): string {
        return this.suffix;
    }

    //   static ucFirst(text: string) {
    //         if (!text) { return text; }
    //         return text.charAt(0).toUpperCase() + text.slice(1);
    //     }

    //   init() {
    //         this.router.events.pipe(
    //             filter((event) => event instanceof NavigationEnd),
    //             map(() => {
    //                 let route = this.activatedRoute;
    //                 while (route.firstChild) { route = route.firstChild; }
    //                 return route;
    //             }),
    //             filter((route) => route.outlet === 'primary'),
    //             map((route) => route.snapshot),
    //             map((snapshot) => {
    //                 if (snapshot.data.title) {
    //                     if (snapshot.paramMap.get('id') !== null) {
    //                         return snapshot.data.title + SEPARATOR + snapshot.paramMap.get('id');
    //                     }
    //                     return snapshot.data.title;
    //                 } else {
    //                     // If not, we do a little magic on the url to create an approximation
    //                     return this.router.url.split('/').reduce((acc, frag) => {
    //                         if (acc && frag) { acc += SEPARATOR; }
    //                         return acc + this.titleService.u(frag);
    //                     });
    //                 }
    //             }))
    //             .subscribe((pathString) => this.titleService.setTitle(`${pathString} - ${APP_TITLE}`));
    //     }
}

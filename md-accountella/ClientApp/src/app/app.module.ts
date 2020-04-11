import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomClarityIcons } from './shared';
import { HeaderNavMenuComponent } from './layout/header-nav-menu/app-header-nav-menu.component';
import { SideNavMenuComponent } from './layout/side-nav-menu/app-side-nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderNavMenuComponent,
    SideNavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    ClarityModule,
    BrowserAnimationsModule
  ],
  providers: [CustomClarityIcons],
  bootstrap: [AppComponent]
})
export class AppModule { }

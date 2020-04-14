import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomClarityIcons } from './shared';
import { HeaderNavMenuComponent } from './layout/header-nav-menu/app-header-nav-menu.component';
import { SideNavMenuComponent } from './layout/side-nav-menu/app-side-nav-menu.component';
import { CoreModule } from './core/core.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderNavMenuComponent,
    SideNavMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CoreModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
      },
    ]),
    ClarityModule,
    BrowserAnimationsModule
  ],
  providers: [CustomClarityIcons, Title],
  bootstrap: [AppComponent]
})
export class AppModule { }

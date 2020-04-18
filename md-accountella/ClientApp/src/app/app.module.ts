import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderNavMenuComponent } from './layout/header-nav-menu/app-header-nav-menu.component';
import { SideNavMenuComponent } from './layout/side-nav-menu/app-side-nav-menu.component';
import { CoreModule } from './core/core.module';
import { NavMenuService } from './services';

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
        loadChildren: () => import('./app-features').then(m => m.DashboardModule)
      },
      {
        path: 'sales',
        loadChildren: () => import('./app-features').then(m => m.SalesModule)
      }
    ]),
    BrowserAnimationsModule,
    ClarityModule
  ],
  providers: [NavMenuService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
// import { RouterModule } from '@angular/router';
// import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
// import { AuctionComponent } from './auction/auction.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    // AuctionComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    // AppRoutingModule,
    HttpClientModule,
    FormsModule,
    // RouterModule.forRoot([
    //   { path: '', component: AuctionComponent, pathMatch: 'full' }
    // ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

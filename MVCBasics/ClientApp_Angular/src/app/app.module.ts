import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { PeopleComponent } from './people/people.component';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [
  
];
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    PeopleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [{ provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { Person } from './person.model';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { PeopleComponent } from './people/people.component';
import { PersonComponent } from './person/person.component';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [
  
];
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    PeopleComponent,
    PersonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'person', component: PeopleComponent }
    ])
  ],
  providers: [{ provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }],
  bootstrap: [AppComponent]
})
export class AppModule { }

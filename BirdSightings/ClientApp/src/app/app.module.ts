import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchSpeciesComponent } from './fetch-species/fetch-species.component';
import { FetchSightingsComponent } from './fetch-sightings/fetch-sightings.component';
import { AddSpeciesComponent } from './add-species/add-species.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchSpeciesComponent,
    FetchSightingsComponent,
    AddSpeciesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-species', component: FetchSpeciesComponent },
      { path: 'fetch-sightings', component: FetchSightingsComponent },
      { path: 'add-species', component: AddSpeciesComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-sightings',
  templateUrl: './fetch-sightings.component.html'
})
export class FetchSightingsComponent {
  public sightings: Sightings[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Sightings[]>(baseUrl + 'api/Sightings').subscribe(result => {
      this.sightings = result;
    }, error => console.error(error));
  }
}

interface Sightings {
  seen: string;
  name: string;
}

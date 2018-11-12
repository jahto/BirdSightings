import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-species',
  templateUrl: './fetch-species.component.html'
})
export class FetchSpeciesComponent {
  public species: Species[];
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    http.get<Species[]>(baseUrl + 'api/Species').subscribe(result => {
      this.species = result;
    }, error => console.error(error));
  }

  public addSighting(species: Species) {
    this.http.post(this.baseUrl + 'api/Sightings', species).subscribe(result => {
      // this.species = result;
    }, error => console.error(error));
  }
}

interface Species {
  id: number;
  name: string;
  total: number;
}

import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-species',
  templateUrl: './fetch-species.component.html'
})
export class FetchSpeciesComponent {
  public species: Species[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Species[]>(baseUrl + 'api/Species').subscribe(result => {
      this.species = result;
    }, error => console.error(error));
  }
}

interface Species {
  id: number;
  name: string;
  total: number;
}

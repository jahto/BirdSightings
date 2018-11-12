import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-species',
  templateUrl: './add-species.component.html'
})
export class AddSpeciesComponent {
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public addSpecies(newspecies: string) {
    let species = new Species();
    species.name = newspecies;
    this.http.post(this.baseUrl + 'api/Species', species).subscribe(result => {
      // this.species = result;
    }, error => console.error(error));
  }
}

class Species {
  id: number;
  name: string;
  total: number;
}

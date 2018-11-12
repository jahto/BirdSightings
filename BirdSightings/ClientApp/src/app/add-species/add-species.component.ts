import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-species',
  templateUrl: './add-species.component.html'
})
export class AddSpeciesComponent {
  http: HttpClient;
  baseUrl: string;
  router: Router;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.router = router;
  }

  public addSpecies(newspecies: string) {
    let species = new Species();
    species.name = newspecies;
    this.http.post(this.baseUrl + 'api/Species', species).subscribe(result => {
      this.router.navigate(['/fetch-species']);
    }, error => console.error(error));
  }
}

class Species {
  id: number;
  name: string;
  total: number;
}

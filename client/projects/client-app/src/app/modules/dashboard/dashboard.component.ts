import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: []
})
export class DashboardComponent implements OnInit {
  authorizedApiResponse: object = {};
  apiResponse: object = {};

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
  }

  testApi() {
    this.http.get(environment.backendUrl + 'test')
      .subscribe(response => {
        this.apiResponse = response;
      })
  }

  testAuthorizedApi() {
    this.http.get(environment.backendUrl + 'test/authorized')
      .subscribe(response => {
        this.authorizedApiResponse = response;
      })

  }
}

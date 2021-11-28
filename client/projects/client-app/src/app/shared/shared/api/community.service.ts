import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { map, Observable, tap } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Community } from "../models/community";

@Injectable({
  providedIn: 'root'
})
export class CommunityService {

  constructor(private http: HttpClient) {
  }

  public getAll(params: { [key: string]: string | number } = {}): Observable<Community[]> {
    return this.http.get<Community[]>(environment.backendUrl + 'communities', {observe: 'response', params})
      .pipe(
        tap(response => {
          console.log(response.headers.keys());//JSON.parse(response.headers.get('Pagination') || '{}'));
        }),
        map(response => response.body as Community[])
      )
  }
}

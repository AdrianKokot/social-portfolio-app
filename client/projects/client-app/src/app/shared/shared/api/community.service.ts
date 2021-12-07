import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable, tap } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Community } from "../models/community";

@Injectable({
  providedIn: 'root'
})
export class CommunityService {
  private actions = {
    all: environment.backendUrl + 'communities',
    get(id: number) {
      return this.all + '/' + id
    },
    join(id: number) {
      return this.get(id) + '/join'
    },
    leave(id: number) {
      return this.get(id) + '/leave'
    }
  }

  constructor(private http: HttpClient) {
  }

  public getAll(params: { [key: string]: string | number } = {}): Observable<Community[]> {
    console.log(params);
    return this.http.get<Community[]>(environment.backendUrl + 'communities', {observe: 'response', params})
      .pipe(
        tap(response => {
          console.log(response.headers.keys());//JSON.parse(response.headers.get('Pagination') || '{}'));
        }),
        map(response => response.body as Community[])
      )
  }

  public get(id: number, params: { [key: string]: string | number } = {}): Observable<Community> {
    return this.http.get<Community>(environment.backendUrl + 'communities/' + id);
  }

  public join(id: number): Observable<void> {
    return this.http.post(this.actions.join(id), {})
      .pipe(map(() => {
      }));
  }

  public leave(id: number): Observable<void> {
    return this.http.delete(this.actions.leave(id), {})
      .pipe(map(() => {
      }));
  }

}

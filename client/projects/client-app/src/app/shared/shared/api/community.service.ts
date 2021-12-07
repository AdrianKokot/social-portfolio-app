import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable, tap } from "rxjs";
import { Community } from "../models/community";
import { apiActions } from "./actions.const";
import { CommunityParams } from "./params/community.params";

@Injectable({
  providedIn: 'root'
})
export class CommunityService {
  private actions = apiActions.community;

  constructor(private http: HttpClient) {
  }

  public getAll(params: Partial<CommunityParams> = {}): Observable<Community[]> {
    return this.http.get<Community[]>(this.actions.root, {observe: 'response', params})
      .pipe(
        tap(response => {
          console.log(response.headers.keys());//JSON.parse(response.headers.get('Pagination') || '{}'));
        }),
        map(response => response.body as Community[])
      )
  }

  public get(id: number, params: Partial<CommunityParams> = {}): Observable<Community> {
    return this.http.get<Community>(this.actions.get(id), {params});
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

import { Injectable } from '@angular/core';
import { apiActions } from "./actions.const";
import { map, Observable, tap } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Discussion } from "../models/discussion";
import { DiscussionParams } from "./params/discussion.params";

@Injectable({
  providedIn: 'root'
})
export class DiscussionService {
  private actions = apiActions.discussion;

  constructor(private http: HttpClient) {
  }

  public getAll(params: Partial<DiscussionParams> = {}): Observable<Discussion[]> {
    return this.http.get<Discussion[]>(this.actions.root, {observe: 'response', params})
      .pipe(
        tap(response => {
          console.log(response.headers.keys());//JSON.parse(response.headers.get('Pagination') || '{}'));
        }),
        map(response => response.body as Discussion[])
      )
  }

  public get(id: number, params: Partial<DiscussionParams> = {}): Observable<Discussion> {
    return this.http.get<Discussion>(this.actions.get(id), {params});
  }
}

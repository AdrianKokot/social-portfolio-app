import { Injectable } from '@angular/core';
import { apiActions } from "./actions.const";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Discussion } from "../models/discussion";
import { DiscussionParams } from "./params/discussion.params";
import { PaginatedResult } from "./paginated-result";

@Injectable({
  providedIn: 'root'
})
export class DiscussionService {
  private actions = apiActions.discussion;

  constructor(private http: HttpClient) {
  }

  public getAll(params: Partial<DiscussionParams> = {}): Observable<PaginatedResult<Discussion>> {
    return this.http.get<PaginatedResult<Discussion>>(this.actions.root, {params});
  }

  public get(id: number, params: Partial<DiscussionParams> = {}): Observable<Discussion> {
    return this.http.get<Discussion>(this.actions.get(id), {params});
  }

  public create(discussion: Partial<Discussion>): Observable<Discussion> {
    return this.http.post<Discussion>(this.actions.root, discussion);
  }
}

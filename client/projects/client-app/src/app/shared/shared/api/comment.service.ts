import { Injectable } from '@angular/core';
import { apiActions } from "./actions.const";
import { HttpClient } from "@angular/common/http";
import { map, Observable, tap } from "rxjs";
import { CommentParams } from "./params/comment.params";
import { Comment } from "../models/comment";

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private actions = apiActions.comment;

  constructor(private http: HttpClient) {
  }

  public getAll(params: Partial<CommentParams> = {}): Observable<Comment[]> {
    return this.http.get<Comment[]>(this.actions.root, {observe: 'response', params})
      .pipe(
        tap(response => {
          console.log(response.headers.keys());//JSON.parse(response.headers.get('Pagination') || '{}'));
        }),
        map(response => response.body as Comment[])
      )
  }

  public create(discussion: Partial<Comment>): Observable<Comment> {
    return this.http.post<Comment>(this.actions.root, discussion);
  }
}

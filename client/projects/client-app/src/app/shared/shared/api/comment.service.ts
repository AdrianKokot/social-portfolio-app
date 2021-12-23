import { Injectable } from '@angular/core';
import { apiActions } from "./actions.const";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CommentParams } from "./params/comment.params";
import { Comment } from "../models/comment";
import { PaginatedResult } from "./paginated-result";

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private actions = apiActions.comment;

  constructor(private http: HttpClient) {
  }

  public getAll(params: Partial<CommentParams> = {}): Observable<PaginatedResult<Comment>> {
    return this.http.get<PaginatedResult<Comment>>(this.actions.root, {params});
  }

  public create(discussion: Partial<Comment>): Observable<Comment> {
    return this.http.post<Comment>(this.actions.root, discussion);
  }
}

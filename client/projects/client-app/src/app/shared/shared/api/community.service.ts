import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Community } from "../models/community";
import { apiActions } from "./actions.const";
import { CommunityParams } from "./params/community.params";
import { PaginatedResult } from "./paginated-result";

@Injectable({
  providedIn: 'root'
})
export class CommunityService {
  private actions = apiActions.community;

  constructor(private http: HttpClient) {
  }

  public getAll(params: Partial<CommunityParams> = {}): Observable<PaginatedResult<Community>> {
    return this.http.get<PaginatedResult<Community>>(this.actions.root, {params});
  }

  public get(id: number, params: Partial<CommunityParams> = {}): Observable<Community> {
    return this.http.get<Community>(this.actions.get(id), {params});
  }

  public join(id: number): Observable<void> {
    return this.http.post<void>(this.actions.join(id), {});
  }

  public leave(id: number): Observable<void> {
    return this.http.delete<void>(this.actions.leave(id), {});
  }

  public create(data: Partial<Community>): Observable<Community> {
    return this.http.post<Community>(this.actions.root, data);
  }
}

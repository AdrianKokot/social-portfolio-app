import { Component, Input, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { Community } from "../../../../../shared/shared/models/community";
import { CommunityService } from "../../../../../shared/shared/api/community.service";

@Component({
  selector: 'app-community-list',
  templateUrl: './community-list.component.html',
  styles: []
})
export class CommunityListComponent implements OnInit {
  @Input() title = 'Communities';
  @Input() limit: number | null | string = null;
  @Input() onlyUserCommunities = false;

  public items$: Observable<Community[]> | null = null;

  constructor(private communityService: CommunityService) {
  }

  ngOnInit(): void {
    this.items$ = this.communityService.getAll(this.limit ? {pageSize: this.limit} : {});
  }

}

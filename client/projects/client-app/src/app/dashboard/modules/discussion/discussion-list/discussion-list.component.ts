import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-discussion-list',
  templateUrl: './discussion-list.component.html',
  styles: []
})
export class DiscussionListComponent implements OnInit {
  @Input() communityId: number | string | null = null;

  constructor() {
  }

  ngOnInit(): void {
  }

}

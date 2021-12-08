import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";

@Component({
  selector: 'app-discussion',
  templateUrl: './discussion.component.html',
  styles: []
})
export class DiscussionComponent {
  public itemId = this.route.snapshot.params["id"];

  public item$ = this.discussionService.get(this.itemId);

  constructor(private route: ActivatedRoute,
              private discussionService: DiscussionService) {
  }

}

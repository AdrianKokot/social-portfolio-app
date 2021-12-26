import {
  AfterViewInit,
  Component,
  ElementRef,
  Input,
  OnDestroy,
  OnInit,
  TrackByFunction,
  ViewChild
} from '@angular/core';
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";
import { filter, finalize, Subject, Subscription, switchMap, tap } from "rxjs";
import { Discussion } from "../../../../shared/shared/models/discussion";
import { DiscussionParams } from "../../../../shared/shared/api/params/discussion.params";

@Component({
  selector: 'app-discussion-list',
  templateUrl: './discussion-list.component.html',
  styles: [],
  host: {
    class: 'block'
  }
})
export class DiscussionListComponent implements OnInit, AfterViewInit, OnDestroy {
  @Input() communityId: number | string | null = null;
  public items: Discussion[] = [];
  public isLoading: boolean = true;
  @ViewChild('infinityBar') infinityBar!: ElementRef<HTMLElement>;
  private order: string = "score desc";
  private subscription: Subscription | null = null;
  private scroll$ = new Subject<void>();
  private hasNextPage = true;
  private observer: IntersectionObserver | null = null;
  private param: Partial<DiscussionParams> = {};

  constructor(
    private discussionService: DiscussionService
  ) {
  }

  @Input() set orderBy(val: string | null) {
    this.order = val !== null ? val : "score desc";

    if (this.param.orderBy !== this.order) {
      console.log('change order');
      this.items = [];
      this.param.page = 0;
      this.hasNextPage = true;
      this.scroll$.next();
    }
  }

  trackById: TrackByFunction<Discussion> = (index: number, item: Discussion) => item.id;

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
    this.observer?.disconnect();
  }

  ngOnInit(): void {

    this.param = {
      communityId: this.communityId !== null ? this.communityId : undefined,
      orderBy: this.order,
      page: 0
    }

    this.subscription = this.scroll$
      .pipe(
        filter(() => this.hasNextPage),
        switchMap(() => {
          this.param.orderBy = this.order;
          this.param.page != undefined && this.param.page++;

          return this.discussionService.getAll(this.param)
            .pipe(
              tap(() => {
                this.isLoading = true;
              }),
              finalize(() => {
                this.isLoading = false;
              })
            )
        })
      )
      .subscribe({
        next: (res) => {
          this.hasNextPage = res.hasNextPage;
          this.items.push(...res.items);
        }
      })
  }

  ngAfterViewInit(): void {
    this.observer = new IntersectionObserver(([entry]) => {
      entry.isIntersecting && this.scroll$.next();
    });

    this.observer.observe(this.infinityBar.nativeElement);
  }
}

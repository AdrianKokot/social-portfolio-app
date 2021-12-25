import {
  AfterViewInit,
  Component,
  ElementRef,
  HostBinding,
  Input,
  OnDestroy,
  OnInit,
  TrackByFunction,
  ViewChild
} from '@angular/core';
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";
import { finalize, Subject, Subscription, switchMap, tap } from "rxjs";
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

  private subscription: Subscription | null = null;
  private scroll$ = new Subject<void>();
  private hasNextPage = true;

  @ViewChild('infinityBar') infinityBar!: ElementRef<HTMLElement>;
  private observer: IntersectionObserver | null = null;


  constructor(
    private discussionService: DiscussionService
  ) {}

  trackById: TrackByFunction<Discussion> = (index: number, item: Discussion) => item.id;

  private tryUnsubscribe() {
    if (!this.hasNextPage) {
      this.unsubscribe();
    }
  }

  private unsubscribe() {
    this.subscription?.unsubscribe();
    this.observer?.disconnect();
  }

  ngOnDestroy(): void {
    this.tryUnsubscribe();
  }

  ngOnInit(): void {
    const param: Partial<DiscussionParams> = {
      communityId: this.communityId !== null ? this.communityId : undefined,
      orderBy: "score desc",
      page: 0
    };

    this.subscription = this.scroll$
      .pipe(
        switchMap(() => {
          param.page != undefined && param.page++;

          console.log('scroll');

          return this.discussionService.getAll(param)
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

          console.log(this.items);

          this.tryUnsubscribe();
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

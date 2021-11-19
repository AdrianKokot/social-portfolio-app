import { Component, ElementRef, HostBinding, HostListener, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { AbstractBodyClickListenerComponent } from "../../../../../shared/shared/abstract-components/components/abstract-body-click-listener/abstract-body-click-listener.component";
import { FormBuilder } from "@angular/forms";
import {
  debounceTime,
  delay,
  distinctUntilChanged,
  filter,
  map,
  Observable,
  of,
  Subscription,
  switchMap,
  tap
} from "rxjs";
import { dropdownAnimation } from "../../../../../shared/shared/animations/dropdown.animation";

@Component({
  selector: 'app-dashboard-nav-search',
  templateUrl: './dashboard-nav-search.component.html',
  styles: [],
  host: {
    class: 'block relative transition-all duration-300 max-w-[18rem] w-full'
  },
  animations: [dropdownAnimation]
})
export class DashboardNavSearchComponent extends AbstractBodyClickListenerComponent implements OnInit, OnDestroy {

  @HostBinding('class') hostClass = '';

  public isSearchInputExtended: boolean = false;

  public searchControl = this.fb.control('', []);
  public isSearchLoading = false;

  public searchResult: string[] = [];

  private searchResult$ = (this.searchControl.valueChanges as Observable<string>)
    .pipe(
      tap(() => {
        this.searchResult = [];
      }),
      debounceTime(300),
      map(searchText => searchText.trim()),
      tap(searchText => {
        this.isSearchLoading = searchText.length > 3;

      }),
      filter(x => x.length > 3),
      distinctUntilChanged(),
      switchMap((searchText) => {
        let arr = [];

        for (let i = 0; i < 5; i++) {
          arr.push(searchText + String.fromCharCode(i * 2 + 97));
        }

        return of(arr)
          .pipe(
            delay(300),
            tap(() => {
              this.isSearchLoading = false;
            })
          );
      })
    );
  private searchResultSubscription: Subscription | null = null;


  constructor(
    private fb: FormBuilder,
    elementRef: ElementRef,
    renderer2: Renderer2) {
    super(elementRef, renderer2);
  }

  ngOnDestroy(): void {
    this.searchResultSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.searchResultSubscription = this.searchResult$.subscribe(result => this.searchResult = result);
  }

  protected override onOutsideComponentBodyClick(): void {
    this.isSearchInputExtended = false;
    this.hostClass = '';

    this.stopBodyClickListening();
  }

  @HostListener('focusin')
  private onFocusIn() {
    this.isSearchInputExtended = true;
    this.hostClass = '!max-w-screen-xs';

    this.startBodyClickListening();
  }

}

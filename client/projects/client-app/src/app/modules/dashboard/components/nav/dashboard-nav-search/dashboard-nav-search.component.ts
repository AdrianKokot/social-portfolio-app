import { Component, ElementRef, HostBinding, HostListener, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-dashboard-nav-search',
  templateUrl: './dashboard-nav-search.component.html',
  styles: [],
  host: {
    class: 'block relative transition-all duration-300 max-w-[18rem] w-full'
  }
})
export class DashboardNavSearchComponent {
  public isSearchBarVisible = false;

  @HostBinding('class') hostClass = '';
  public isSearchBarResultVisible = false;
  public searchText: string = '';
  private unlistenOutsideClick: (() => void) | null = null;

  constructor(
    private elementRef: ElementRef,
    private renderer2: Renderer2) {
  }

  public search(value: string): void {
    this.isSearchBarResultVisible = value.length > 3;
  }

  @HostListener('focusin')
  private onFocusIn() {
    this.isSearchBarVisible = true;
    this.hostClass = '!max-w-screen-xs';

    this.listenOutsideClick();
  }

  private blur() {
    this.isSearchBarVisible = false;
    this.hostClass = '';

    if (this.unlistenOutsideClick) {
      this.unlistenOutsideClick();
    }
  }

  private listenOutsideClick(): void {
    if (this.unlistenOutsideClick !== null) {
      return;
    }
    this.unlistenOutsideClick = this.renderer2.listen(document.body, 'click', e => {
      const clickedOutsideComponent: boolean = !e.composedPath().includes(this.elementRef.nativeElement);

      if (clickedOutsideComponent) {
        this.blur();
      }

    });
  }
}

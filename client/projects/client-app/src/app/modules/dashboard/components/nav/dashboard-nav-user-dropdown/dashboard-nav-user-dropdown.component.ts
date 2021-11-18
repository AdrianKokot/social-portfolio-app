import { Component, ElementRef, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-dashboard-nav-user-dropdown',
  templateUrl: './dashboard-nav-user-dropdown.component.html',
  styles: [],
  host: {
    class: 'block relative select-none'
  }
})
export class DashboardNavUserDropdownComponent {

  public isDropdownVisible: boolean = false;
  private unlistenOutsideClick: (() => void) | null = null;

  constructor(private elementRef: ElementRef,
              private renderer2: Renderer2) {
  }

  public show() {
    this.isDropdownVisible = true;

    this.listenOutsideClick();
  }

  public hide() {
    this.isDropdownVisible = false;

    if (this.unlistenOutsideClick) {
      this.unlistenOutsideClick();
    }
  }

  private listenOutsideClick(): void {
    this.unlistenOutsideClick = this.renderer2.listen(document.body, 'click', e => {
      const clickedOutsideComponent: boolean = !e.composedPath().includes(this.elementRef.nativeElement);

      if (clickedOutsideComponent) {
        this.hide();
      }

    });
  }

  toggle() {
    if (this.isDropdownVisible) {
      this.hide();
    } else {
      this.show();
    }
  }
}

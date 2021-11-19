import { Component, ElementRef, Renderer2 } from '@angular/core';

@Component({template: ''})
export class AbstractBodyClickListenerComponent {

  constructor(
    private elementRef: ElementRef,
    private renderer2: Renderer2) {
  }

  protected stopBodyClickListening(): void {
  };

  protected onOutsideComponentBodyClick(): void {
  };

  protected onInsideComponentBodyClick(): void {
  };

  protected startBodyClickListening(): void {
    this.stopBodyClickListening();

    this.stopBodyClickListening = this.renderer2.listen(document.body, 'click', e => {
      const clickedInsideComponent: boolean = e.composedPath().includes(this.elementRef.nativeElement);

      if (clickedInsideComponent) {
        this.onInsideComponentBodyClick();
      } else {
        this.onOutsideComponentBodyClick();
      }

    });
  }
}

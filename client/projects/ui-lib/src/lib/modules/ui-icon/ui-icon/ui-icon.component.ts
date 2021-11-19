import { Component, HostBinding, Input, ViewEncapsulation } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { uiIcons } from '../icons';

@Component({
  selector: 'ui-icon',
  styles: [
    `ui-icon {
      @apply inline-block;
      @apply focus:outline-none;
      @apply flex-shrink-0;
    }`
  ],
  encapsulation: ViewEncapsulation.None,
  template: `
    <svg xmlns="http://www.w3.org/2000/svg"
         class="w-full h-full fill-current"
         viewBox="0 0 24 24"
         stroke-width="2"
         [innerHTML]="icons[icon]">
    </svg>
  `
})
export class UIIconComponent {
  public icons: { [key: string]: SafeHtml } = {};
  private selectedIcon: string = '';
  private cssSizeClasses = 'w-6 h-6';
  private cssClasses = '';
  @HostBinding('class') private hostClass = this.cssSizeClasses;

  constructor(private sanitizer: DomSanitizer) {
  }

  @Input()
  public set sizeClass(value: string) {
    this.cssSizeClasses = value;
    this.updateHostCssClasses();
  }

  @Input()
  public set class(value: string) {
    this.cssClasses = value;
    this.updateHostCssClasses();
  }

  public get icon(): string {
    return this.selectedIcon;
  }

  @Input()
  public set icon(icon: string) {
    this.selectedIcon = icon in uiIcons ? icon : 'default';

    this.icons[this.selectedIcon] = this.sanitizer.bypassSecurityTrustHtml(uiIcons[this.selectedIcon]);
  }

  private updateHostCssClasses(): void {
    this.hostClass = `${this.cssClasses} ${this.cssSizeClasses}`;
  }

}

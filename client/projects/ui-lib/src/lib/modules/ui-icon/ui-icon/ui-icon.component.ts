import { Component, HostBinding, Input } from '@angular/core';
import { SafeHtml, DomSanitizer } from '@angular/platform-browser';
import { uiIcons } from '../icons';

@Component({
  selector: 'ui-icon',
  styles: [],
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
  private selectedIcon = '';
  public defaultHostClass = 'inline-block focus:outline-none flex-shrink-0';
  public defaultSizeClass = 'w-6 h-6';

  @HostBinding('class') private hostClass = this.defaultSizeClass + ' ' + this.defaultHostClass;

  @Input() public set class(v: string) {
    this.hostClass = v + ' ' + this.defaultHostClass;
  }

  @Input() public set icon(icon: string) {
    this.selectedIcon = icon in this.icons ? icon : 'default';
  }

  public get icon(): string {
    return this.selectedIcon;
  }

  public icons: { [key: string]: SafeHtml } = {};

  constructor(private sanitizer: DomSanitizer) {
    for (const key of Object.keys(uiIcons)) {
      this.icons[key] = this.sanitizer.bypassSecurityTrustHtml(uiIcons[key]);
    }
  }

}

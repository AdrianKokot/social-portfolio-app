import { Component } from '@angular/core';

@Component({
  selector: 'ui-loading',
  styles: [],
  host: {
    class: 'block'
  },
  template: `
    <svg
      class="h-full m-auto"
      id="L4"
      viewBox="0 0 52 50"
      x="0px"
      xml:space="preserve"
      xmlns="http://www.w3.org/2000/svg"
      y="0px">
      <circle cx="6"
              cy="25"
              fill="currentColor"
              r="6"
              stroke="none">
        <animate attributeName="opacity"
                 begin="0.1"
                 dur="1.5s"
                 repeatCount="indefinite"
                 values="0;1;0"/>
      </circle>
      <circle cx="26"
              cy="25"
              fill="currentColor"
              r="6"
              stroke="none">
        <animate attributeName="opacity"
                 begin="0.2"
                 dur="1.5s"
                 repeatCount="indefinite"
                 values="0;1;0"/>
      </circle>
      <circle cx="46"
              cy="25"
              fill="currentColor"
              r="6"
              stroke="none">
        <animate attributeName="opacity"
                 begin="0.3"
                 dur="1.5s"
                 repeatCount="indefinite"
                 values="0;1;0"/>
      </circle>
    </svg>
  `
})
export class UiLoadingComponent {
}

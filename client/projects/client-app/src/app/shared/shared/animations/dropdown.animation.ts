import { animate, style, transition, trigger } from "@angular/animations";

const styleWhenNotVisible = style({
  transform: 'translateY(-1rem)',
  opacity: 0
});

const styleWhenVisible = style({
  transform: 'translateY(0)',
  opacity: 1
});

export const dropdownAnimation = trigger("dropdownAnimation", [
  transition(
    ':enter',
    [styleWhenNotVisible, animate('.1s', styleWhenVisible)]
  ),
  transition(
    ':leave',
    [styleWhenVisible, animate('.1s', styleWhenNotVisible)]
  )
]);

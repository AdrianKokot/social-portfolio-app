import {
  animate,
  AnimationStyleMetadata,
  AnimationTriggerMetadata,
  style,
  transition,
  trigger
} from "@angular/animations";

export class CustomAnimationBuilder {
  private styleWhenNotVisible: AnimationStyleMetadata = style({});
  private styleWhenVisible: AnimationStyleMetadata = style({});

  public withHiddenStyle(tokens: { [p: string]: string | number }): CustomAnimationBuilder {
    this.styleWhenNotVisible = style(tokens);

    return this;
  }

  public withVisibleStyle(tokens: { [p: string]: string | number }): CustomAnimationBuilder {
    this.styleWhenVisible = style(tokens);

    return this;
  }

  public build(animationName: string): AnimationTriggerMetadata {
    return trigger(animationName, [
      transition(
        ':enter',
        [this.styleWhenNotVisible, animate('.1s', this.styleWhenVisible)]
      ),
      transition(
        ':leave',
        [this.styleWhenVisible, animate('.1s', this.styleWhenNotVisible)]
      )
    ]);

  }

}

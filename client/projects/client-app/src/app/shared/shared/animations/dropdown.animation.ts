import { CustomAnimationBuilder } from "./custom-animation-builder";

export const dropdownAnimation = (new CustomAnimationBuilder())
  .withHiddenStyle({
    transform: 'translateY(-1rem)',
    opacity: 0
  })
  .withVisibleStyle({
    transform: 'translateY(0)',
    opacity: 1
  })
  .build("dropdownAnimation");

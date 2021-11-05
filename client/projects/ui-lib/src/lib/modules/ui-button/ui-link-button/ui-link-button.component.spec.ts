import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UiLinkButtonComponent } from './ui-link-button.component';

describe('UiLinkButtonComponent', () => {
  let component: UiLinkButtonComponent;
  let fixture: ComponentFixture<UiLinkButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UiLinkButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UiLinkButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

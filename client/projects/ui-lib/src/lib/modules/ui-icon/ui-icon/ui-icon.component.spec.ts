import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UIIconComponent } from './ui-icon.component';

describe('UIIconComponent', () => {
  let component: UIIconComponent;
  let fixture: ComponentFixture<UIIconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UIIconComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UIIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormsTextareaComponent } from './forms-textarea.component';

describe('FormsTextareaComponent', () => {
  let component: FormsTextareaComponent;
  let fixture: ComponentFixture<FormsTextareaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormsTextareaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormsTextareaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

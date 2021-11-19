import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbstractBodyClickListenerComponent } from './abstract-body-click-listener.component';

describe('AbstractBodyClickListenerComponent', () => {
  let component: AbstractBodyClickListenerComponent;
  let fixture: ComponentFixture<AbstractBodyClickListenerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbstractBodyClickListenerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbstractBodyClickListenerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

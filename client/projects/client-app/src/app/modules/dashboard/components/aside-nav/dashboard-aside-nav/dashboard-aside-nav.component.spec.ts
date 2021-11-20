import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardAsideNavComponent } from './dashboard-aside-nav.component';

describe('DashboardAsideNavComponent', () => {
  let component: DashboardAsideNavComponent;
  let fixture: ComponentFixture<DashboardAsideNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardAsideNavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardAsideNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

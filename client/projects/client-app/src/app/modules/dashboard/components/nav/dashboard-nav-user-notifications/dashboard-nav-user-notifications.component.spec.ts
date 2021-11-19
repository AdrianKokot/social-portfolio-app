import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardNavUserNotificationsComponent } from './dashboard-nav-user-notifications.component';

describe('DashboardNavUserNotificationsComponent', () => {
  let component: DashboardNavUserNotificationsComponent;
  let fixture: ComponentFixture<DashboardNavUserNotificationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardNavUserNotificationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardNavUserNotificationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

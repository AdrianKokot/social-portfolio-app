import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardNavUserDropdownComponent } from './dashboard-nav-user-dropdown.component';

describe('DashboardNavUserDropdownComponent', () => {
  let component: DashboardNavUserDropdownComponent;
  let fixture: ComponentFixture<DashboardNavUserDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardNavUserDropdownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardNavUserDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

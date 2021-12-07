import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardNavSearchComponent } from './dashboard-nav-search.component';

describe('DashboardNavSearchComponent', () => {
  let component: DashboardNavSearchComponent;
  let fixture: ComponentFixture<DashboardNavSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardNavSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardNavSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideBarCollapsedComponent } from './side-bar-collapsed.component';

describe('SideBarCollapsedComponent', () => {
  let component: SideBarCollapsedComponent;
  let fixture: ComponentFixture<SideBarCollapsedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SideBarCollapsedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SideBarCollapsedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

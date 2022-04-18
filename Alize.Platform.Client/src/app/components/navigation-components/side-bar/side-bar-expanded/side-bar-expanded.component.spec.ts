import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideBarExpandedComponent } from './side-bar-expanded.component';

describe('SideBarExpandedComponent', () => {
  let component: SideBarExpandedComponent;
  let fixture: ComponentFixture<SideBarExpandedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SideBarExpandedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SideBarExpandedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

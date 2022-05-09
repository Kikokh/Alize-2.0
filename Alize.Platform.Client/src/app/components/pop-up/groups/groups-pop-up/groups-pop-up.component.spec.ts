import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupsPopUpComponent } from './groups-pop-up.component';

describe('GroupsPopUpComponent', () => {
  let component: GroupsPopUpComponent;
  let fixture: ComponentFixture<GroupsPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupsPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupsPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

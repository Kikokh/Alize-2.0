import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupUserPopUpComponent } from './group-user-pop-up.component';

describe('GroupUserPopUpComponent', () => {
  let component: GroupUserPopUpComponent;
  let fixture: ComponentFixture<GroupUserPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupUserPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupUserPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

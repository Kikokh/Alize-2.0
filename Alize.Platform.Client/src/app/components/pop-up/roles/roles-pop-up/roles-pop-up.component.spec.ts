import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RolesPopUpComponent } from './roles-pop-up.component';

describe('GroupsPopUpComponent', () => {
  let component: RolesPopUpComponent;
  let fixture: ComponentFixture<RolesPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RolesPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RolesPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditUserPopUpComponent } from './edit-user-pop-up.component';

describe('EditUserPopUpComponent', () => {
  let component: EditUserPopUpComponent;
  let fixture: ComponentFixture<EditUserPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditUserPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditUserPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordUserPopUpComponent } from './password-user-pop-up.component';

describe('PasswordUserPopUpComponent', () => {
  let component: PasswordUserPopUpComponent;
  let fixture: ComponentFixture<PasswordUserPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PasswordUserPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PasswordUserPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

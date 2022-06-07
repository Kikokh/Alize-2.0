import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationPopUpComponent } from './application-pop-up.component';

describe('ApplicationPopUpComponent', () => {
  let component: ApplicationPopUpComponent;
  let fixture: ComponentFixture<ApplicationPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

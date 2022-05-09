import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationGroupPopUpComponent } from './application-group-pop-up.component';

describe('ApplicationGroupPopUpComponent', () => {
  let component: ApplicationGroupPopUpComponent;
  let fixture: ComponentFixture<ApplicationGroupPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationGroupPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationGroupPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

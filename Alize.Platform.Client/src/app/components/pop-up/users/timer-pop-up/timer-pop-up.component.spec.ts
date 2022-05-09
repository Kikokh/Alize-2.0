import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimerPopUpComponent } from './timer-pop-up.component';

describe('TimerPopUpComponent', () => {
  let component: TimerPopUpComponent;
  let fixture: ComponentFixture<TimerPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimerPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimerPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

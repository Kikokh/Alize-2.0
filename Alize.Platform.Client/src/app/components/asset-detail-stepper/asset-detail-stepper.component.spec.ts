import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetDetailStepperComponent } from './asset-detail-stepper.component';

describe('AssetDetailStepperComponent', () => {
  let component: AssetDetailStepperComponent;
  let fixture: ComponentFixture<AssetDetailStepperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssetDetailStepperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetDetailStepperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

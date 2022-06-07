import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalizatorComponent } from './totalizator.component';

describe('TotalizatorComponent', () => {
  let component: TotalizatorComponent;
  let fixture: ComponentFixture<TotalizatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TotalizatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalizatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

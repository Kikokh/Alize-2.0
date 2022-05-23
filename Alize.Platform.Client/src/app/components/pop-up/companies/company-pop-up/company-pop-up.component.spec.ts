import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyPopUpComponent } from './company-pop-up.component';

describe('CompanyPopUpComponent', () => {
  let component: CompanyPopUpComponent;
  let fixture: ComponentFixture<CompanyPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompanyPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

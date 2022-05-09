import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModulesPopUpComponent } from './modules-pop-up.component';

describe('ModulesPopUpComponent', () => {
  let component: ModulesPopUpComponent;
  let fixture: ComponentFixture<ModulesPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModulesPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModulesPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

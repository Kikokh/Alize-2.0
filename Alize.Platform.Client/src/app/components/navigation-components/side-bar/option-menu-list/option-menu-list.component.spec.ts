import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptionMenuListComponent } from './option-menu-list.component';

describe('OptionMenuListComponent', () => {
  let component: OptionMenuListComponent;
  let fixture: ComponentFixture<OptionMenuListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptionMenuListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OptionMenuListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

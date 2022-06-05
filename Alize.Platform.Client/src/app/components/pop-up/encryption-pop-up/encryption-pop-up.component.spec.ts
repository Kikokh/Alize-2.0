import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EncryptionPopUpComponent } from './encryption-pop-up.component';

describe('EncryptionPopUpComponent', () => {
  let component: EncryptionPopUpComponent;
  let fixture: ComponentFixture<EncryptionPopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EncryptionPopUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EncryptionPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

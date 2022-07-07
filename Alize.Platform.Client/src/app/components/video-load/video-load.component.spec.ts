import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoLoadComponent } from './video-load.component';

describe('VideoLoadComponent', () => {
  let component: VideoLoadComponent;
  let fixture: ComponentFixture<VideoLoadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideoLoadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoLoadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

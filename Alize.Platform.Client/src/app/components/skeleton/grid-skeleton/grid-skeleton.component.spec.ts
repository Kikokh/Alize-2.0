import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridSkeletonComponent } from './grid-skeleton.component';

describe('GridSkeletonComponent', () => {
  let component: GridSkeletonComponent;
  let fixture: ComponentFixture<GridSkeletonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GridSkeletonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GridSkeletonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

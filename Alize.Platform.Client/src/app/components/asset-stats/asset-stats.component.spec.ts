import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetStatsComponent } from './asset-stats.component';

describe('AssetStatsComponent', () => {
  let component: AssetStatsComponent;
  let fixture: ComponentFixture<AssetStatsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssetStatsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetStatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

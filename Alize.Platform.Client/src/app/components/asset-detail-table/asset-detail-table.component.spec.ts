import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetDetailTableComponent } from './asset-detail-table.component';

describe('AssetDetailTableComponent', () => {
  let component: AssetDetailTableComponent;
  let fixture: ComponentFixture<AssetDetailTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssetDetailTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetDetailTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

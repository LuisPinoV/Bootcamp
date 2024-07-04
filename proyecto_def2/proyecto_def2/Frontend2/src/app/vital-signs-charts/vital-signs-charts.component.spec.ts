import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VitalSignsChartsComponent } from './vital-signs-charts.component';

describe('VitalSignsChartsComponent', () => {
  let component: VitalSignsChartsComponent;
  let fixture: ComponentFixture<VitalSignsChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VitalSignsChartsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VitalSignsChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

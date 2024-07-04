import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VitaLuxComponent } from './vita-lux.component';

describe('VitaLuxComponent', () => {
  let component: VitaLuxComponent;
  let fixture: ComponentFixture<VitaLuxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VitaLuxComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VitaLuxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PiesaComponent } from './piesa.component';

describe('PiesaComponent', () => {
  let component: PiesaComponent;
  let fixture: ComponentFixture<PiesaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PiesaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PiesaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PieseComponent } from './piese.component';

describe('PieseComponent', () => {
  let component: PieseComponent;
  let fixture: ComponentFixture<PieseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PieseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PieseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditMasinaComponent } from './add-edit-masina.component';

describe('AddEditMasinaComponent', () => {
  let component: AddEditMasinaComponent;
  let fixture: ComponentFixture<AddEditMasinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditMasinaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditMasinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPiesaComponent } from './add-edit-piesa.component';

describe('AddEditPiesaComponent', () => {
  let component: AddEditPiesaComponent;
  let fixture: ComponentFixture<AddEditPiesaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPiesaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPiesaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAppliedJobComponent } from './create-applied-job.component';

describe('CreateAppliedJobComponent', () => {
  let component: CreateAppliedJobComponent;
  let fixture: ComponentFixture<CreateAppliedJobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateAppliedJobComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateAppliedJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

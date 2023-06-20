import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AzStorageComponent } from './az-storage.component';

describe('AzStorageComponent', () => {
  let component: AzStorageComponent;
  let fixture: ComponentFixture<AzStorageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AzStorageComponent]
    });
    fixture = TestBed.createComponent(AzStorageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

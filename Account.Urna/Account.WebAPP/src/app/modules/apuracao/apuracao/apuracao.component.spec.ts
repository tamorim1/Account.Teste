import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApuracaoComponent } from './apuracao.component';

describe('ApuracaoComponent', () => {
  let component: ApuracaoComponent;
  let fixture: ComponentFixture<ApuracaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApuracaoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApuracaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

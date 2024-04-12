import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';

import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'CDB  Calculator'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('CDB  Calculator');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).toContain('CDB  Calculator app is running!');
  });
  it('form should be invalid when empty', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    expect(fixture.componentInstance.investmentForm.valid).toBeFalsy();
  });

  it('amount field should be required', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const amount = fixture.componentInstance.investmentForm.controls['amount'];
    expect(amount.valid).toBeFalsy();

    const errors = amount.errors || {};
    expect(errors['required']).toBeTruthy();
  });

  it('durationInMonths field should be required', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const durationInMonths = fixture.componentInstance.investmentForm.controls['durationInMonths'];
    expect(durationInMonths.valid).toBeFalsy();

    const errors = durationInMonths.errors || {};
    expect(errors['required']).toBeTruthy();
  });

  it('amount field should accept positive values', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const amount = fixture.componentInstance.investmentForm.controls['amount'];
    amount.setValue(100);
    expect(amount.valid).toBeTruthy();
  });

  it('durationInMonths field should accept values greater than 1', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const durationInMonths = fixture.componentInstance.investmentForm.controls['durationInMonths'];
    durationInMonths.setValue(2);
    expect(durationInMonths.valid).toBeTruthy();
  });

  it('should submit form and receive results', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    
    const app = fixture.componentInstance;
    const mockResponse = { resultadoBruto: 110, resultadoLiquido: 220 };

    // spyOn(, 'post').and.returnValue(of(mockResponse));

    // component.investmentForm.setValue({ amount: 100, durationInMonths: 2 });
    // component.onSubmit();

    // expect(component.resultadoBruto).toEqual(mockResponse.resultadoBruto);
    // expect(component.resultadoLiquido).toEqual(mockResponse.resultadoLiquido);
  });
});

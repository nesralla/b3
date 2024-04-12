import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
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
    const amount = fixture.componentInstance.investmentForm.controls['valorInvestido'];
    expect(amount.valid).toBeFalsy();

    const errors = amount.errors || {};
    expect(errors['required']).toBeTruthy();
  });

  it('durationInMonths field should be required', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const durationInMonths = fixture.componentInstance.investmentForm.controls['prazoEmMeses'];
    expect(durationInMonths.valid).toBeFalsy();

    const errors = durationInMonths.errors || {};
    expect(errors['required']).toBeTruthy();
  });

  it('Valor investido field should accept positive values', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const amount = fixture.componentInstance.investmentForm.controls['valorInvestido'];
    amount.setValue(100);
    expect(amount.valid).toBeTruthy();
  });

  it('durationInMonths field should accept values greater than 1', () => {
     const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const durationInMonths = fixture.componentInstance.investmentForm.controls['prazoEmMeses'];
    durationInMonths.setValue(2);
    expect(durationInMonths.valid).toBeTruthy();
  });

  
});

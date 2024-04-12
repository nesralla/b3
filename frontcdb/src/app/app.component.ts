import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements  OnInit {
  title = 'CDB  Calculator';
  investmentForm!: FormGroup;
  valorBruto: number = 0;
  valorLiquido: number = 0;

  constructor(private fb: FormBuilder, private http: HttpClient) { }
    
  ngOnInit() {
    this.investmentForm = this.fb.group({
      valorInvestido: ['', [Validators.required, Validators.min(0.01)]],
      prazoEmMeses: ['', [Validators.required, Validators.min(2)]]
    });
  }
   onSubmit() {
       if (!this.investmentForm) return; // Check if form is initialized
    this.http.post<any>('https://localhost:5001/api/Simulador', this.investmentForm.value)
      .subscribe(response => {
        this.valorBruto = response.ValorBruto;
        this.valorLiquido = response.ValorLiquido;
      });
  }
}

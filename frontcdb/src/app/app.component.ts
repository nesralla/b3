import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements  OnInit {
  title = 'CDB  Calculator';
  investmentForm!: FormGroup;
  resultadoBruto: number = 0;
  resultadoLiquido: number = 0;

  constructor(private fb: FormBuilder, private http: HttpClient) { }
    
  ngOnInit() {
    this.investmentForm = this.fb.group({
      amount: ['', [Validators.required, Validators.min(0.01)]],
      durationInMonths: ['', [Validators.required, Validators.min(2)]]
    });
  }
   onSubmit() {
   
  }
}

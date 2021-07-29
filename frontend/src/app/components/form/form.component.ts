import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  summaryForm = this.formBuilder.group({
    minutes: ''
  });

  constructor(
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  onSubmit(){
    let minutes: number = this.summaryForm.value.minutes;
    if (!minutes || minutes<=0){
      alert("Wprowadź dodatnią liczbę minut");
      return;
    }
    this.router.navigateByUrl(`/summary/${minutes}`);
  }
}

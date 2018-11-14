
import { Component } from '@angular/core';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  //----------------PROPERTIRS-------------------
  formGroup: FormGroup;
  obj: typeof Object = Object;

  //----------------CONSTRUCTOR------------------
  constructor() {
    let formGroupConfig = {
      userName: new FormControl("Test", this.createValidatorArr("name", 3, 15)),
      userPassword: new FormControl("123456", this.createValidatorArr("password", 6, 10))
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }

  //----------------METHODS-------------------
  submitLogin() {
    console.log(this.formGroup.value);
    console.log(this.formGroup.controls);
    alert(this.formGroup.status)
  }


  createValidatorArr(cntName: string, min: number, max: number): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null
    ];
  }
}

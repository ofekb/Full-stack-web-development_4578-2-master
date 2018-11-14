import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthenticationService } from './../shared/services/authentication.service';

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authenticationService: AuthenticationService) { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });

        // reset login status
        this.authenticationService.logout();
    }

    // convenience getter for easy access to form fields
    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (!this.loginForm.invalid) {
            this.loading = true;
            this.error = "";
            this.authenticationService.login(this.f.username.value, this.f.password.value)
                .subscribe(
                    data => {
                        if (data) {
                            this.router.navigate(["/AuthRout/home"]);
                        }
                        else {
                            setTimeout(()=>{
                                this.error = "user name or password are not ok";
                                this.loading = false;
                            },3000)
                        }
                    });
        }
    }
}

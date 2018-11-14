import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent }  from './app.component';
import { routing }        from './app.routing';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthenticationService } from './shared/services/authentication.service';
import { UserService } from './shared/services/user.service';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        routing
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent
    ],
    providers: [
        AuthenticationService,
        UserService   
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
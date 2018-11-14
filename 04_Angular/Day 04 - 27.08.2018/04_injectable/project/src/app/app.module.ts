import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CounterService } from './shared/services/counter.service';
import { MathService } from './shared/services/math.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [MathService,CounterService],
  bootstrap: [AppComponent]
})
export class AppModule { }

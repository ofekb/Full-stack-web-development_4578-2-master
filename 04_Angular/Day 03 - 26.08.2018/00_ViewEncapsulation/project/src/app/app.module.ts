import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NonModeComponent } from './non-mode/non-mode.component';
import { EmulatedModeComponent } from './emulated-mode/emulated-mode.component';
import { ShadowDomModeComponent } from './shadow-dom-mode/shadow-dom-mode.component';

@NgModule({
  declarations: [
    AppComponent,
    NonModeComponent,
    EmulatedModeComponent,
    ShadowDomModeComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

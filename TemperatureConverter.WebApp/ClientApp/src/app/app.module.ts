import { BrowserModule } from '@angular/platform-browser';
import { APP_BASE_HREF } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TempConverterComponent } from '../temp-converter/temp-converter.component';
import { TemperatureService } from './core/TemperatureService';


@NgModule({
  declarations: [
    AppComponent,
    TempConverterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [
    TemperatureService,

    { provide: APP_BASE_HREF, useValue: '' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

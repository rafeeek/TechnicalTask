import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PermissionsModule } from './modules/permissions/permissions.module';
import { DataModule } from './data/data.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


// PrimeNG
import {AccordionModule} from 'primeng/accordion';   


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    PermissionsModule,
    DataModule,
    BrowserModule,
    AppRoutingModule,
    AccordionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

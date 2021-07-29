import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeButtonComponent } from './components/home-button/home-button.component';
import { FormComponent } from './components/form/form.component';
import { TableComponent } from './components/table/table.component';
import { ChartComponent } from './components/chart/chart.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeButtonComponent,
    FormComponent,
    TableComponent,
    ChartComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

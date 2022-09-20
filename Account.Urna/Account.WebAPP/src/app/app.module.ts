import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ToolbarAllModule } from '@syncfusion/ej2-angular-navigations';
import { HomeComponent } from './home/home.component';
import { CandidatoServiceModule } from './services/candidato/candidato.service';
import { VotoServiceModule } from './services/voto/voto.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ToolbarAllModule,
    CandidatoServiceModule.forRoot(),
    VotoServiceModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

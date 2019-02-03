import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatMenuModule, MatButtonModule, MatCheckboxModule, MatIconModule } from '@angular/material';
import { GoogleChartsModule } from 'angular-google-charts';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { TemperatureHistoryComponent } from './chart/history/temperature/temperature.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TemperatureHistoryComponent
  ],
  imports: [
    BrowserAnimationsModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    GoogleChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

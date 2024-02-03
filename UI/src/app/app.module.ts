import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { SharedModule } from './shared/shared.module'
import { HomeComponent } from './home/home.component'
import { LoginComponent } from './login/login.component'
import { LayoutModule } from './layout/layout.module'

@NgModule({
  declarations: [AppComponent, HomeComponent, LoginComponent],
  imports: [LayoutModule, BrowserModule, AppRoutingModule, SharedModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}

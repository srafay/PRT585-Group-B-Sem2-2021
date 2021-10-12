import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';
import { AppRoutingModule } from './app-routing.module';
import { CrudModule } from './crud/crud.module';




@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,
    CoreModule,
    ShopModule,
    AppRoutingModule,
    CrudModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { HomeComponent } from './home/home.component';
import { ViewProductsComponent } from './seller/view-products/view-products.component';
import { AddProductsComponent } from './seller/add-products/add-products.component';
import { BuyComponent } from './buyer/buy/buy.component';
import { ViewComponent } from './buyer/view/view.component';
import { DepositComponent } from './buyer/deposit/deposit.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent,
    ViewProductsComponent,
    AddProductsComponent,
    BuyComponent,
    ViewComponent,
    DepositComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

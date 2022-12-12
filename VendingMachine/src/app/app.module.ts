import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from "@auth0/angular-jwt";
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { HomeComponent } from './home/home.component';
import { ViewProductsComponent } from './seller/view-products/view-products.component';
import { AddProductsComponent } from './seller/add-products/add-products.component';
import { BuyComponent } from './buyer/buy/buy.component';
import { ViewComponent } from './buyer/view/view.component';
import { DepositComponent } from './buyer/deposit/deposit.component';
import { SellerHomeComponent } from './seller/seller-home/seller-home.component';
import { BuyerHomeComponent } from './buyer/buyer-home/buyer-home.component';
import { AuthGuardService } from './guards/auth-guard.service';

export function tokenGetter() {
  return localStorage.getItem("access_token");
}

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
    DepositComponent,
    SellerHomeComponent,
    BuyerHomeComponent
  ],
  imports: [
    BrowserModule, 
    BrowserAnimationsModule,
    HttpClientModule, 
    AppRoutingModule, 
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["https://localhost:4200"],
        disallowedRoutes: [],
      },
    }),
    ToastrModule.forRoot(),
  ],
  providers: [AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { BuyComponent } from './buyer/buy/buy.component';
import { BuyerHomeComponent } from './buyer/buyer-home/buyer-home.component';
import { DepositComponent } from './buyer/deposit/deposit.component';
import { ViewComponent } from './buyer/view/view.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { HomeComponent } from './home/home.component';
import { AddProductsComponent } from './seller/add-products/add-products.component';
import { SellerHomeComponent } from './seller/seller-home/seller-home.component';
import { ViewProductsComponent } from './seller/view-products/view-products.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

const routes: Routes = [
  {path: "", pathMatch:  "full",redirectTo:  "/home"},
  { path: 'home', component: HomeComponent, canActivate: [AuthGuardService]  },
  { path: 'login', component: LoginComponent },
  { path: 'signUp', component: SignupComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'buyer/home', component: BuyerHomeComponent, canActivate: [AuthGuardService] },
  { path: 'buyer/buy', component: BuyComponent, canActivate: [AuthGuardService]  },
  { path: 'buyer/deposit', component: DepositComponent, canActivate: [AuthGuardService]  },
  { path: 'buyer/view', component: ViewComponent, canActivate: [AuthGuardService]  },
  { path: 'seller/view', component: ViewProductsComponent, canActivate: [AuthGuardService]  },
  { path: 'seller/add/:productId', component: AddProductsComponent, canActivate: [AuthGuardService]  },
  { path: 'seller/home', component: SellerHomeComponent , canActivate: [AuthGuardService] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
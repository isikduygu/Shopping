import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SellerManagmentComponent } from './admin/seller-managment/seller-managment.component';
import { AuthGuard } from './guards/common/auth.guard';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BasketComponent } from './user/basket/basket.component';
import { ProductsComponent } from './user/products/products.component';

const routes: Routes = [
  { path: 'products-managment', component: SellerManagmentComponent, canActivate: [AuthGuard]},
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '', component: ProductsComponent },
  { path: ':id', component: ProductsComponent },
  { path: 'cart', component: BasketComponent, canActivate: [AuthGuard] }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

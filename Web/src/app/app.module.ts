import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MatButtonModule } from '@angular/material/button';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { SellerManagmentComponent } from './admin/seller-managment/seller-managment.component';
import { ProductListComponent } from './admin/product-list/product-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { MatIconModule} from '@angular/material/icon';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { JwtModule } from "@auth0/angular-jwt";
import { AddProductComponent } from './admin/products/add-product/add-product.component';
import { EditProductComponent } from './admin/products/edit-product/edit-product.component';
import { PhotoProductComponent } from './admin/products/photo-product/photo-product.component';
import { UploadFileModule } from './admin/upload-file/upload-file.module';
import { ProductsComponent } from './user/products/products.component';
import { BasketComponent } from './user/basket/basket.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AddProductComponent,
    SellerManagmentComponent,
    ProductListComponent,
    EditProductComponent,
    RegisterComponent,
    LoginComponent,
    PhotoProductComponent,
    ProductsComponent,
    BasketComponent,
  ],
  imports: [
    BrowserModule,
    MatButtonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    BrowserAnimationsModule,
    NgbModule,
    AppRoutingModule,
    MatIconModule,
    SweetAlert2Module,
    UploadFileModule,
    ReactiveFormsModule.withConfig({warnOnNgModelWithFormControl: 'never'}), // It looks like you're using ngModel on the same form field as formControlName. 
    JwtModule.forRoot({
      config: {
        tokenGetter : () => localStorage.getItem("accessToken"),
        allowedDomains : ["localhost:7162"]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

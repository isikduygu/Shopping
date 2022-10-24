import { Component, OnInit } from '@angular/core';
import { IProduct } from '../models/IProduct';
import { AuthService } from '../services/auth.service';
import { ProductService } from '../services/products.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public authService: AuthService) {
    authService.identityCheck();
   }
  products: any;

  ngOnInit(): void {
  }
  signOut(){
    localStorage.removeItem('accessToken');
    localStorage.removeItem('userId');
    this.authService.identityCheck();
  }
}

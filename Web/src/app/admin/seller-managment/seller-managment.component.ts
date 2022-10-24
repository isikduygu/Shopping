import { Component, OnInit, ViewChild } from '@angular/core';
import { IProduct } from 'src/app/models/IProduct';
import { ProductService } from 'src/app/services/products.service';
import { ProductListComponent } from '../product-list/product-list.component';

@Component({
  selector: 'app-seller-managment',
  templateUrl: './seller-managment.component.html',
  styleUrls: ['./seller-managment.component.css'],
})
export class SellerManagmentComponent implements OnInit {
  products: IProduct[] = [];

  constructor(private productsService: ProductService) {}

  @ViewChild(ProductListComponent)
  ListComponent!: ProductListComponent;

  ngOnInit(): void {}
   createProducts(_products : IProduct) {
    this.ListComponent.getProducts();
  }
}


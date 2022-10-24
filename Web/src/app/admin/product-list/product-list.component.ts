import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { IProduct } from 'src/app/models/IProduct';
import { ProductService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  products : IProduct [] = [];
  constructor(private productsService : ProductService) { }
  
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;


  ngOnInit(): void {
    this.getProducts();
  }
  getProducts() {
    this.productsService
      .getAllProducts( this.paginator ? this.paginator.pageIndex : 0, this.paginator ? this.paginator.pageSize : 5)
      .subscribe({
        next: (response : any) => {
          this.products = response.products;
          this.paginator.length = response.totalCount;
        },
      });
  }
  onPageChange() {
    this.getProducts();
  }
}

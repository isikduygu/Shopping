import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IBasket, IBasketItem } from 'src/app/models/IBasket';
import { IProduct } from 'src/app/models/IProduct';
import { IProductImage } from 'src/app/models/IProductImage';
import { AuthService, _isAuthenticated } from 'src/app/services/auth.service';
import { BasketService } from 'src/app/services/basket.service';
import { ProductImageService } from 'src/app/services/product-image.service';
import { ProductService } from 'src/app/services/products.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  constructor(
    private productsService: ProductService,
    private activatedRoute: ActivatedRoute,
    private productImageService: ProductImageService,
    private basketService: BasketService,
    private router: Router,
    private toastService : ToastService
  ) {}

  products: IProduct[] = [];
  productImages!: IProductImage[];
  totalCount!: number;
  pageSize: number = 12;
  totalPageNo!: number;
  currentPageNo!: number;
  pageList!: number[];
  baseUrl!: string;

  currentStock!: number;

  basketItem: IBasketItem = {
    id: 0,
    productName: '',
    price: 0,
    quantity: 0,
    pictureUrl: '',
  };
  basket: IBasket = {
    id: '',
    items: [],
  };

  ngOnInit(): void {
    this.getProduct();
    this.BaseUrl();
  }

  getProduct() {
    this.activatedRoute.params.subscribe((params) => {
      this.currentPageNo = parseInt(params['id'] ?? 1);
      this.productsService
        .getAllProducts(this.currentPageNo - 1, this.pageSize)
        .subscribe(async (response) => {
          this.products = response.products;
          this.totalCount = response.totalCount;
          this.totalPageNo = Math.ceil(this.totalCount / this.pageSize);

          console.log(this.products);
          this.pageList = [];

          if (this.totalPageNo >= 7) {
            if (this.currentPageNo - 3 <= 0) {
              for (var i = 0; i < 7; i++) {
                this.pageList.push(i);
              }
            } else if (this.currentPageNo + 3 >= this.totalPageNo) {
              for (let i = this.totalPageNo - 6; i <= this.totalPageNo; i++) {
                this.pageList.push(i);
              }
            } else {
              for (
                let i = this.currentPageNo - 3;
                i <= this.currentPageNo + 3;
                i++
              ) {
                this.pageList.push(i);
              }
            }
          } else {
            for (let i = 1; i <= this.totalPageNo; i++) {
              this.pageList.push(i);
            }
          }
        });
    });
  }

  BaseUrl() {
    this.productImageService.getBaseUrl().subscribe((response) => {
      this.baseUrl = response;
    });
  }

  addToList(product: any) {
    let productItem = {
      id: product.id,
      productName: product.name,
      price: product.price,
      quantity: 1,
      pictureUrl: '',
    };
    if (_isAuthenticated) {
      this.basket.id = localStorage.getItem('userId') as string;

      if (product.stock >= productItem.quantity) {
        let found = false;
        for (var i = 0; i < this.basket.items.length; i++) {
          if (this.basket.items[i].id == productItem.id) {
            found = true;
            product.stock > 0 ? (product.stock -= 1) : (product.stock = 0);
            product.stock >= productItem.quantity
              ? (this.basket.items[i].quantity += 1)
              : (product.stock = 0);
            break;
          }
        }
        if (found == false) {
          this.basket.items.push(productItem);
        }
      } else {
        product.stock = 0;
      }
      if (product.stock == 0) {
        this.toastService.showToast({
          icon: 'warning',
          title: 'Maximum value',
        })
      } else {
        this.basketService.updateBasket(this.basket).subscribe((response) => {
          console.log('successfully added');
          console.log(response);
        });
      }
    } else {
      this.router.navigate(['/login']);
    }
  }
}

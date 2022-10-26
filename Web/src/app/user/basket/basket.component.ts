import { Component, OnInit } from '@angular/core';
import { IBasketItem } from 'src/app/models/IBasket';
import { BasketService } from 'src/app/services/basket.service';
import { ProductImageService } from 'src/app/services/product-image.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  constructor(private basketService: BasketService, private productImageService : ProductImageService) { }
  baseUrl!: string;
  basketItems! : IBasketItem[];
  amount! : number;

  ngOnInit(): void {
    this.getBasket();
    this.BaseUrl();
  }
  getBasket(){
    let userId = localStorage.getItem("userId") as any;
    this.basketService.getBasket(userId)
    .subscribe(response => {
      this.basketItems = response.items;
      let totalAmount =0;
      for(let i = 0; i < this.basketItems.length; i++){
        totalAmount += (this.basketItems[i].price * this.basketItems[i].quantity);
      }
      this.amount = totalAmount
    })
  }

  BaseUrl() {
    this.productImageService.getBaseUrl().subscribe((response) => {
      this.baseUrl = response;
    });
  }

}

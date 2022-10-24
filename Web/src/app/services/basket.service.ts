import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBasket } from '../models/IBasket';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private httpClient : HttpClient) { }

  basketApiUrl: string = environment.basketApiUrl;

  getBasket(id : number): Observable<IBasket> {
    return this.httpClient.get<IBasket>(
      this.basketApiUrl + '/Basket?id=' + id);
  }

  updateBasket(basket : IBasket): Observable<IBasket> {
    return this.httpClient.post<IBasket>(
      this.basketApiUrl + '/Basket' , basket);
  }

  deleteBasketItem(id: number): Observable<IBasket> {
    return this.httpClient.delete<IBasket>(
      this.basketApiUrl + '/Basket?id=' + id);
  }
}

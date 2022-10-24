import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProduct } from '../models/IProduct';
import { IApiResponse } from '../models/IApiResponse';
import { IProductSingle } from '../models/IProductSingle';

@Injectable({ providedIn: 'root' })
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  apiUrl: string = environment.apiUrl;

  getAllProducts(page: number = 0, size:number = 5): Observable<IApiResponse> {
    return this.httpClient.get<IApiResponse>(
      `${environment.apiUrl}/Products?page=${page}&size=${size}`
    );
  }
  getSingleProducts(id : number): Observable<IProductSingle> {
    return this.httpClient.get<IProductSingle>(
      this.apiUrl + '/Products/' + id);
  }

  createProducts(product : IProduct): Observable<IApiResponse> {
    return this.httpClient.post<IApiResponse>(
      this.apiUrl + '/Products', product);
  }

  updateProducts(product : IProduct): Observable<IApiResponse> {
    return this.httpClient.put<IApiResponse>(
      this.apiUrl + '/Products', product);
  }
  deleteProducts(id : number): Observable<IApiResponse> {
    return this.httpClient.delete<IApiResponse>(
      this.apiUrl + '/Products/' + id);
  }
}

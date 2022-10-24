import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProductImage } from '../models/IProductImage';

@Injectable({
  providedIn: 'root'
})
export class ProductImageService {

  constructor(private httpClient: HttpClient) { }
  apiUrl: string = environment.apiUrl;

  async getProductImage(id : number): Promise<Observable<IProductImage[]>> {
    return this.httpClient.get<IProductImage[]>(
      this.apiUrl + '/Products/GetProductImages/' + id);
  }
  deleteProductImage(id : number, imageId: number): Observable<IProductImage[]> {
    return this.httpClient.delete<IProductImage[]>(
      `${environment.apiUrl}/Products/DeleteProductImage/${id}?imageId=${imageId}`);
  }
  getBaseUrl(){
    return this.httpClient.get(
      this.apiUrl + '/File', {responseType: 'text'})
  }
}

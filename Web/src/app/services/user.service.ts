import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, observable, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUser } from '../models/IUser';
import { IUserApiResponse } from '../models/IUserApiResponse';
import { ILoginUser } from '../models/ILoginUser';
import { Token } from '../models/Token';
import { TokenResponse } from '../models/TokenResponse';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  apiUrl: string = environment.apiUrl;

  createUser(user : IUser): Observable<IUserApiResponse> {
    return this.httpClient.post<IUserApiResponse>(
      this.apiUrl + '/User' , user
    );
  }
  loginUser(loginUser : ILoginUser): Observable<TokenResponse> {
    return this.httpClient.post<TokenResponse>(
      this.apiUrl + '/User/Login' , loginUser
    );
  }
}

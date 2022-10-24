import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper : JwtHelperService) { }

  identityCheck (){
    const token = localStorage.getItem('accessToken') as string;

    // const decodeToken = this.jwtHelper.decodeToken(token);
    // const expirationDate = this.jwtHelper.getTokenExpirationDate(token) as Date;
    let expired : boolean;

 try{
  expired = this.jwtHelper.isTokenExpired(token);
 }catch{
  expired = true;
 }
 _isAuthenticated = token != null && !expired;
  }

  get Authenticated () : boolean {
    return _isAuthenticated;
  }
}
export let _isAuthenticated : boolean;

import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from "@auth0/angular-jwt";
import { ToastService } from 'src/app/services/toast.service';
import { AuthService, _isAuthenticated } from 'src/app/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private jwtHelper : JwtHelperService,
     private router: Router,
      private toastService: ToastService,
      private authService: AuthService){
  }
  canActivate(
    route: ActivatedRouteSnapshot,state: RouterStateSnapshot) {

  //     const token = localStorage.getItem('accessToken') as string;

  //     // const decodeToken = this.jwtHelper.decodeToken(token);
  //     // const expirationDate = this.jwtHelper.getTokenExpirationDate(token) as Date;
  //     let expired : boolean;

  //  try{
  //   expired = this.jwtHelper.isTokenExpired(token);
  //  }catch{
  //   expired = true;
  //  }
   if(!_isAuthenticated){
    this.router.navigate(['/login'], {queryParams: { returnUrl: state.url}});
    this.toastService.showToast({
      icon: 'warning',
      title: "You have to login",
    });
   }

    return true;
  }
}

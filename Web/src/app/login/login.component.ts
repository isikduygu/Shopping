import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILoginUser } from '../models/ILoginUser';
import { AuthService } from '../services/auth.service';
import { ToastService } from '../services/toast.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  errorMessage!: string;
  submitted : boolean = false;

  userLogin : ILoginUser = {
    emailorUserName: '',
    password: ''
  }

  constructor(private toastService : ToastService,
     private userService: UserService,
     private router: Router,
     private authService: AuthService,
     private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {
  }
  loginForm= new FormGroup({
    emailorUserName: new FormControl("",[Validators.required]),
    password : new FormControl("",[Validators.required]),
    
  });
  
login(){
  this.submitted = true;
    this.userLogin.emailorUserName = this.loginForm.value.emailorUserName as string,
    this.userLogin.password = this.loginForm.value.password as string,


    this.userService
    .loginUser(this.userLogin)
    .subscribe( {
      next: (data) => {
        console.log(data)
        this.router.navigate(['/']);
        localStorage.setItem('accessToken', data.token.accessToken);
        localStorage.setItem('userId', data.id);
        this.authService.identityCheck();

        this.activatedRoute.queryParams.subscribe(params => {
          const returnUrl : string = params['returnUrl'];
          if(returnUrl){
            this.router.navigate([returnUrl]);
          }
        })
      },
      error: (error) => {
        console.log(error);

        this.toastService.showToast({
          icon: 'error',
          title: "Username or password invalid",
        });
      },
  })
}
}

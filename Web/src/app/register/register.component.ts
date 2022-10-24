import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IUser } from '../models/IUser';
import { ToastService } from '../services/toast.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  submitted = false;
  errorMessage! : string;

  constructor(private userService: UserService, private toastService : ToastService) { }

  ngOnInit(): void {
  }
  registerForm= new FormGroup({
    nameSurname:new FormControl("",[Validators.required]),
    username: new FormControl("",[Validators.required]),
    email: new FormControl("",[Validators.required]),
    password : new FormControl("",[Validators.required]),
    passwordConfirm: new FormControl("",[Validators.required, Validators.minLength(6)]),
    
  });

  user : IUser = {
    nameSurname: '',
    email: '',
    username: '',
    password: '',
    passwordConfirm: '',
    id: ''
  }
  submit(){
    this.submitted = true;
    this.user.nameSurname = this.registerForm.value.nameSurname as string,
    this.user.username = this.registerForm.value.username as string,
    this.user.email = this.registerForm.value.email as string,
    this.user.password = this.registerForm.value.password as string,
    this.user.passwordConfirm = this.registerForm.value.passwordConfirm as string;

    this.userService
    .createUser(this.user)
    .subscribe((response) => {
      if(response.succeeded === true) {
        this.toastService.showToast({
          icon: 'success',
          title: 'Successfully registered.',
        })
        this.errorMessage = "";
        // this.navigate.route('/login');
      }else{
        this.errorMessage = response.message;
      }
    });
  }
}

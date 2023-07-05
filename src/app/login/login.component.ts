import { Component, ViewChild } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

  @ViewChild("myForm") myform : any;
  error_msg: any;

  constructor(private authService : AuthService,private router:Router) { }

  login(){
    let username = this.myform.value.username;
    let password = this.myform.value.password;
    
    if(this.authService.login(username,password)){
      this.router.navigate(['home']);
    }
    else{
      this.error_msg = "Invalid username or password";
    }
  
  }
  
    

}

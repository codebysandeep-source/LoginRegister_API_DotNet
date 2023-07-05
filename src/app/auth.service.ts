import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private readonly validUsername = "Admin";
  private readonly validPassword = "Password";

  login(username:string,password:string) : boolean{

    if(username === this.validUsername && password === this.validPassword){
      //set item in local storage
      localStorage.setItem('isLoggedIn','true');
      return true;
    }
    else{
      return false;
    }
  }

  logout() : void{
    //clear or remove set item from local storage
    localStorage.removeItem('isLoggedIn');
  }

  isLoggedIn() : boolean{
    //check item
    return localStorage.getItem('isLoggedIn') === 'true';
  }


  }
  


 


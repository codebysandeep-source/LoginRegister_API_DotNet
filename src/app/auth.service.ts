import { Injectable } from '@angular/core';
import { HttpClient } from  '@angular/common/http';
import { error } from 'console';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  constructor(private http: HttpClient){}


  login(username:string,password:string) : boolean{

    let userdata: any = {
      'username':username,
      'password':password
    };
    
    let return_result : boolean = false;
    let san = this.http.post("https://localhost:44308/api/Login",userdata).subscribe(
      (res : any)=>{

         if(res.result === 'Login Successful'){
            //set item in local storage
            localStorage.setItem('user_token',res.token);
            return_result = true;
          }
          else{
            return_result = false;
          }

      },
      (error)=>{
        console.log(error);
        return false;
      },
      () => {
        return_result = true;
        // Handle completion here (using complete)
        console.log('Data fetching completed.', return_result);
      }
    );
    console.log(san);
    return return_result;
  }

  logout() : void{
    //clear or remove set item from local storage
    localStorage.removeItem('user_token');
  }

  isLoggedIn() : boolean{
    //check item
    return  localStorage.getItem('user_token') !== null;
  }
  

  }
  


 


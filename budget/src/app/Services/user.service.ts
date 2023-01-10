import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../Classes/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly V_API = environment.ApiUrl+'/User';

  constructor(
    private http: HttpClient
  ) { }

  LoginUserByID(id: string, pass: string): Observable<boolean> {
    const p=new HttpParams().set('idUser',id).set('password',pass);
    
    // return this.http.get<boolean>(this.V_API + '/LoginUserByID/'+id+'/');
    return this.http.get<boolean>(this.V_API + '/LoginUserByID',{params:p});
  }

  GetUserByID(id: string): Observable<User> {
    const p=new HttpParams().set('idUser',id);
    
    return this.http.get<User>(this.V_API + '/GetUserByID',{params:p});
  }

  // newUser:User=new User();
  //  newUser.FirstName=FirstName;
  //  newUser.LastName',LastName)
  //  newUser.Id',userId)
  //  newUser.Phone',Phone)
  //  newUser.Email',Email)
  //  newUser.DateBirth',DateBirth)
  //  newUser.password',password);

  AddUser(newUser:User):Observable<boolean> {
       // const p=new HttpParams().set()
        // .set('FirstName',FirstName)
        // .set('LastName',LastName)
        // .set('Id',userId)
        // .set('Phone',Phone)
        // .set('Email',Email)
        // .set('DateBirth',DateBirth)
        // .set('password',password);
        return this.http.post<boolean>(this.V_API + '/AddUser',{newUser});
  }
  // AddUser(newUser: User): Observable<boolean> {
  //   const u=new HttpParams().set('userDTO',newUser);
    
  //   return this.http.post<boolean>(this.V_API + '/AddUser',{params:u});
  // }
  
  // UpdateUser(newUser: User): Observable<boolean> {
  //   const u=new HttpParams().set('userDTO',newUser);
    
  //   return this.http.post<boolean>(this.V_API + '/UpdateUser',{params:u});
  // }

}

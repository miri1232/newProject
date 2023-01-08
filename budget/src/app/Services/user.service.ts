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
}

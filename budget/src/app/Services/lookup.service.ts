import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { PaymentMethod } from '../Classes/PaymentMethod';
import { PermissionLevel } from '../Classes/PermissionLevel';
import { Status } from '../Classes/Status';
import { TypeBudget } from '../Classes/TypeBudget';
import { Bank } from '../Classes/Bank';


@Injectable({
  providedIn: 'root'
})
export class LookupService {
  
  readonly V_API = environment.ApiUrl+'/Lookup';

  constructor(
    private http : HttpClient
  ) { }


  GetAllTypeBudget(): Observable<TypeBudget[]> {
    const typeBudget=new HttpParams(); 
    return this.http.get<TypeBudget[]>(this.V_API + '/GetAllTypeBudget');
  }

 GetAllStatus(): Observable<Status[]> {
    const status=new HttpParams(); 
    return this.http.get<Status[]>(this.V_API + '/GetAllStatus');
  }

  GetAllPaymentMethod(): Observable<PaymentMethod[]> {
    const paymentMethod=new HttpParams(); 
    return this.http.get<PaymentMethod[]>(this.V_API + '/GetAllPaymentMethod');
  }

  GetAllPermissionLevel(): Observable<PermissionLevel[]> {
    const permissionLevel=new HttpParams(); 
    return this.http.get<PermissionLevel[]>(this.V_API + '/GetAllPermissionLevel');
  }
  
  GetAllBank():Observable<Bank[]>{
    const bank=new HttpParams(); 
    return this.http.get<Bank[]>(this.V_API + '/GetAllBank');
  }


}

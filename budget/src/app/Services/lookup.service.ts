import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { TypeBudget } from '../Classes/TypeBudget';

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

}

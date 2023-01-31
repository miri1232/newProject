import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SourceOfIncome } from '../Classes/SourceOfIncome';

@Injectable({
  providedIn: 'root'
})
export class SourceOfIncomeService {

  readonly V_API = environment.ApiUrl+'/SourceOfIncome';


  constructor(
    private http : HttpClient
  ) { }

  GetAllSourceOfIncomes(): Observable<SourceOfIncome[]> {
    const sourceOfIncome=new HttpParams();
    
    return this.http.get<SourceOfIncome[]>(this.V_API + '/GetAllSourceOfIncomes');
  }


}

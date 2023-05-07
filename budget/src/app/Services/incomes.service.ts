import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Income } from '../Classes/Income';

@Injectable({
  providedIn: 'root'
})
export class IncomesService {
  readonly V_API = environment.ApiUrl+'/Income';

  constructor(
    private http : HttpClient
  ) { }
  
  GetAllIncomes(): Observable<Income[]>{
        return this.http.get<Income[]>(this.V_API+'/GetAllIncomes');
  }
  
  GetIncomesByBudget(idBudget:number): Observable<Income[]>{
        return this.http.get<Income[]>(this.V_API+'/GetIncomesByBudget/'+idBudget);
  }
  
   
 

AddIncome(newIncome:Income):Observable<boolean> {
  
  return this.http.post<boolean>(this.V_API + '/AddIncome',newIncome);
}
UpdateIncome(incomeToUpdate: Income): Observable<boolean> {
  return this.http.put<boolean>(this.V_API + '/UpdateIncome', incomeToUpdate);

}



}



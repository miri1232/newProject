import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Expense } from '../Classes/Expense';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {

  readonly V_API = environment.ApiUrl+'/Expense';

  
  constructor(
    private http : HttpClient
    ) { }

    GetAllExpenses(): Observable<Expense[]>{
          return this.http.get<Expense[]>(this.V_API+'/GetAllExpenses');
    }

      GetExpensesByCategory(ctg:string):Observable<Expense[]>{
            return this.http.get<Expense[]>(this.V_API+'/GetExpensesByCategory');
      }
        
      AddExpense(newExpense :Expense):Observable<boolean> {
      return this.http.post<boolean>(this.V_API + '/AddExpense',newExpense);
  }



}

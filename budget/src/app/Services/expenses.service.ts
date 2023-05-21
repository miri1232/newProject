import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Expense } from '../Classes/Expense';
import { TotalSumCategory } from '../Classes/TotalSumCategory copy';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {

  readonly V_API = environment.ApiUrl + '/Expense';


  constructor(
    private http: HttpClient
  ) { }

  GetAllExpenses(): Observable<Expense[]> {
    return this.http.get<Expense[]>(this.V_API + '/GetAllExpenses');
  }

  GetExpensesByBudget(idBudget: number): Observable<Expense[]> {
    return this.http.get<Expense[]>(this.V_API + '/GetExpensesByBudget/' + idBudget);
  }


  // GetExpensesByCategory(ctg: number): Observable<Expense[]> {
  //   return this.http.get<Expense[]>(this.V_API + '/GetExpensesByCategory', ctg);
  // }

  AddExpense(newExpense: Expense): Observable<boolean> {
    return this.http.post<boolean>(this.V_API + '/AddExpense', newExpense);
  }

  UpdateExpense(expenseToUpdate: Expense): Observable<boolean> {
    return this.http.put<boolean>(this.V_API + '/UpdateExpense', expenseToUpdate);

  }

  ReportExpenses2(idBudget: number): Observable<TotalSumCategory[]> {
    return this.http.get<TotalSumCategory[]>(this.V_API + '/ReportExpenses2/' + idBudget);
  }

 ReportExpenses3(idBudget: number,start:Date, end:Date, status:number): Observable<TotalSumCategory[]> {
    return this.http.get<TotalSumCategory[]>(this.V_API + '/ReportExpenses3/' + idBudget +"/"+ start +"/"+end +"/"+status);
  }

  
// listCategory: TotalSumCategory[] = [];

//  ReportExpenses2(idBudget: number,start:Date, end:Date): Observable<TotalSumCategory[]> {

// const url = `this.V_API+ '/ReportExpenses2/'+?idBudget=${this.activeBudget.id}&start=${this.DateStart}&end=${this.DateEnd}`;
// this.http.get<TotalSumCategory[]>(url).subscribe(response => {
// this.listCategory=response;
// });
//     return this.listCategory;
//   }


     
}

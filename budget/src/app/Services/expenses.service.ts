import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Expense } from '../Classes/Expense';
import { ObjectSumSubCategory } from '../Classes/ObjectSumSubCategory';
import { ObjectSumCategory } from '../Classes/ObjectSumCategory';

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
    return this.http.get<Expense[]>(this.V_API + '/GetExpensesByBudget/'+ idBudget);
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

ReportSubCategoryExpenses(idBudget: number): Observable<ObjectSumSubCategory[]> {
  return this.http.get<ObjectSumSubCategory[]>(this.V_API + '/ReportSubCategoryExpenses/'+ idBudget);
}

ReportCategoryExpenses(idBudget: number): Observable<ObjectSumCategory[]> {
  return this.http.get<ObjectSumCategory[]>(this.V_API + '/ReportCategoryExpenses/'+ idBudget);
}

}

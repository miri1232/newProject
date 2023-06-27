import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Expense } from '../Classes/Expense';
import { TotalSumCategory } from '../Classes/TotalSumCategory';
import { map } from 'rxjs/operators';
import { Search } from '../Classes/Search';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {

  readonly V_API = environment.ApiUrl + '/Expense';

  private expenseList = new BehaviorSubject<Expense[]>([]);
  sharedexpenseList$ = this.expenseList.asObservable();

  private repotrExp = new BehaviorSubject<TotalSumCategory[]>([]);
  sharedreportExp$ = this.repotrExp.asObservable();

  constructor(
    private http: HttpClient
  ) { }

  // ExpensesByDate(idBudget: number) {
  //   this.http.get<Expense[]>(this.V_API + '/ExpensesByDate/' + idBudget).subscribe(res => {
  //     this.expenseList.next(res);
  //   });
  // }

  SearchExpensesObject(s: Search){
     this.http.post<Expense[]>(this.V_API + '/SearchExpensesObject/' , s).subscribe(res => {
      this.expenseList.next(res);
    });
  }
  
  AddExpense(newExpense: Expense): Observable<boolean> {
    return this.http.post<Expense>(this.V_API + '/AddExpense', newExpense).pipe(
      map((res: any) => {
        var list = this.expenseList.getValue();
        list.push(res);
        this.expenseList.next(list);
        return true;
      })
    );
  }

  UpdateExpense(expenseToUpdate: Expense): Observable<boolean> {
    // return this.http.put<boolean>(this.V_API + '/UpdateExpense', expenseToUpdate);
    return this.http.put<Expense>(this.V_API + '/UpdateExpense', expenseToUpdate).pipe(
      map((res: any) => {
        var list = this.expenseList.getValue();
        var index = list.findIndex(expense => expense.id === res.id);
        if (index !== -1) {
          list[index] = res;
          this.expenseList.next(list)};
          return true;
        })
    );
  }

  // ReportExpenses2(idBudget: number): Observable<TotalSumCategory[]> {
  //   return this.http.get<TotalSumCategory[]>(this.V_API + '/ReportExpenses2/' + idBudget);
  // }

  ReportExpenses3(s: Search) {
    this.http.post<TotalSumCategory[]>(this.V_API + '/ReportExpenses3/' , s).subscribe(res => {
      this.repotrExp.next(res);
    });
  }

}

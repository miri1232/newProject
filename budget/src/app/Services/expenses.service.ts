import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Expense } from '../Classes/Expense';
import { TotalSumCategory } from '../Classes/TotalSumCategory copy';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {

  readonly V_API = environment.ApiUrl + '/Expense';

  private expenseList = new BehaviorSubject<Expense[]>([]);
  sharedexpenseList$ = this.expenseList.asObservable();

  constructor(
    private http: HttpClient
  ) { }


  GetAllExpenses() {
    this.http.get<Expense[]>(this.V_API + '/GetAllExpenses').subscribe(res => {
      this.expenseList.next(res);
    });
  }

  GetExpensesByBudget(idBudget: number) {
    this.http.get<Expense[]>(this.V_API + '/GetExpensesByBudget/' + idBudget).subscribe(res => {
      this.expenseList.next(res);
    });
  }


  // GetExpensesByCategory(ctg: number): Observable<Expense[]> {
  //   return this.http.get<Expense[]>(this.V_API + '/GetExpensesByCategory', ctg);
  // }

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

  ReportExpenses2(idBudget: number): Observable<TotalSumCategory[]> {
    return this.http.get<TotalSumCategory[]>(this.V_API + '/ReportExpenses2/' + idBudget);
  }

  ReportExpenses3(idBudget: number, start: Date, end: Date, status: number): Observable<TotalSumCategory[]> {
    return this.http.get<TotalSumCategory[]>(this.V_API + '/ReportExpenses3/' + idBudget + "/" + start + "/" + end + "/" + status);
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

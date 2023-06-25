import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Income } from '../Classes/Income';
import { TotalSumCategoryIncome } from '../Classes/TotalSumCategoryIncome';
import { Search } from '../Classes/Search';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class IncomesService {
  readonly V_API = environment.ApiUrl+'/Income';

  private incomeList = new BehaviorSubject<Income[]>([]);
  sharedIncomeList$ = this.incomeList.asObservable();

  private repotrInc = new BehaviorSubject<TotalSumCategoryIncome[]>([]);
  sharedreportInc$ = this.repotrInc.asObservable();

  constructor(
    private http : HttpClient
  ) { }
  
  GetAllIncomes(): Observable<Income[]>{
        return this.http.get<Income[]>(this.V_API+'/GetAllIncomes');
  }
  
  GetIncomesByBudget(idBudget:number): Observable<Income[]>{
        return this.http.get<Income[]>(this.V_API+'/GetIncomesByBudget/'+idBudget);
  }

  SearchIncomesObject(s: Search){
    this.http.post<Income[]>(this.V_API + '/SearchIncomesObject/' , s).subscribe(res => {
     this.incomeList.next(res);
   });
 }
  
  ReportIncomes(s: Search) {
    this.http.post<TotalSumCategoryIncome[]>(this.V_API + '/ReportIncomes/' , s).subscribe(res => {
      this.repotrInc.next(res);
    });
  }
 

AddIncome(newIncome:Income):Observable<boolean> {
  
  return this.http.post<boolean>(this.V_API + '/AddIncome',newIncome);
}
UpdateIncome(incomeToUpdate: Income): Observable<boolean> {
  return this.http.put<boolean>(this.V_API + '/UpdateIncome', incomeToUpdate);

}



}



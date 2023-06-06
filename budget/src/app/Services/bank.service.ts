import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Logging } from 'src/shared/log.service';
import { BankOfBudget } from '../Classes/BankOfBudget';
import { map } from 'rxjs/operators';
import { Budget } from '../Classes/Budget';

@Injectable({
  providedIn: 'root'
})
export class BankService {


  readonly V_API = environment.ApiUrl+'/BankOfBudget';

  public bankList = new BehaviorSubject<BankOfBudget[]>([]);
  sharedBankList$ = this.bankList.asObservable();

  activeBudget!: Budget;

  
  constructor(
    private log:Logging,
    private http : HttpClient 
     ) { 
      
     }

     ngOnInit(): void {
      this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)
  
    }

        //שליפת רשימת בנקים לפי מספר תקציב
        GetBankOfBudgetByIdBudget(idBudget:number){

      // const categoryIncome=new HttpParams();
      this.http.get<BankOfBudget[]>(this.V_API + '/GetBankOfBudgetByIdBudget/'+idBudget).subscribe(res =>{
        this.bankList.next(res);
      });
     return this.bankList; 
    }

    AddBankOfBudget(newBank:BankOfBudget):Observable<boolean> {
      return this.http.post<BankOfBudget>(this.V_API + '/AddBankOfBudget',newBank).pipe(
        map((res: any) => {
          var list = this.bankList.getValue();
          list.push(res);
          this.bankList.next(list);
          return true;
        })
      );
  }


}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Logging } from 'src/shared/log.service';
import { BankOfBudget } from '../Classes/BankOfBudget';

@Injectable({
  providedIn: 'root'
})
export class BankService {


  readonly V_API = environment.ApiUrl+'/BankOfBudget';

  constructor(
    private log:Logging,
    private http : HttpClient  ) { }


        //שליפת רשימת בנקים לפי מספר תקציב
    GetBankOfBudgetByIdBudget():Observable<BankOfBudget[]>{
      const categoryIncome=new HttpParams();
    
      return this.http.get<BankOfBudget[]>(this.V_API + '/GetBankOfBudgetByIdBudget'+'/6');
   
    }

    AddBankOfBudget(newBank:BankOfBudget):Observable<boolean> {

      return this.http.post<boolean>(this.V_API + '/AddBankOfBudget',newBank);
  }


}

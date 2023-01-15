import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Logging } from 'src/shared/log.service';
import { Budget } from '../Classes/Budget';

@Injectable({
  providedIn: 'root'
})
export class BudgetService {

  readonly V_API = environment.ApiUrl+'/Budget';
  
  constructor(
    private log:Logging,
    private http : HttpClient
  ) { }

  GetBudgetByUser(): Observable<Budget[]>{
        return this.http.get<Budget[]>(this.V_API+'/GetBudgetByUser'+this.log.ActiveUser.Id);
      }
    
    


}

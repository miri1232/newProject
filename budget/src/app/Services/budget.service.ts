import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Logging } from 'src/shared/log.service';
import { Budget } from '../Classes/Budget';
import { User } from '../Classes/User';

@Injectable({
  providedIn: 'root'
})
export class BudgetService {

  readonly V_API = environment.ApiUrl + '/Budget';

  constructor(
    private log: Logging,
    private http: HttpClient
  ) { }

  GetBudgetById(id: number): Observable<Budget> {
    return this.http.get<Budget>(this.V_API + '/GetBudgetByID/' + id);
  }


  GetBudgetByUser(activeUser:User): Observable<Budget[]> {
    return this.http.get<Budget[]>(this.V_API + '/GetBudgetByUser/' + activeUser.id);
  }




  AddBudget(newBudget: Budget): Observable<boolean> {
    return this.http.post<boolean>(this.V_API + '/AddBudget', newBudget);
  }




}

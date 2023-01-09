import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryIncomeService {

  readonly V_API = environment.ApiUrl+'/CategoryIncome';

  constructor(
    private http : HttpClient
  ) { }
  
}

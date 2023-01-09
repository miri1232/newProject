import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SourceOfIncomeService {

  readonly V_API = environment.ApiUrl+'/SourceOfIncome';


  constructor(
    private http : HttpClient
  ) { }


}

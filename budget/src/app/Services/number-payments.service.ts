import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NumberPaymentsService {

  readonly V_API = environment.ApiUrl+'/NumberPayments';


  constructor(
    private http : HttpClient
  ) { }

}

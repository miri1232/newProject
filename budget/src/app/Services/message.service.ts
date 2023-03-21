import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  readonly V_API = environment.ApiUrl+'/Message';
public a:string="שלום";

  constructor(
    private http : HttpClient
  ) { }

}

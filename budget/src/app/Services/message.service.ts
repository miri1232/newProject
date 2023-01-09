import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  readonly V_API = environment.ApiUrl+'/Message';


  constructor(
    private http : HttpClient
  ) { }

}

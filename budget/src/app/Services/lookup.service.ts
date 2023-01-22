import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LookupService {
  
  readonly V_API = environment.ApiUrl+'/Lookup';

  constructor(
    private http : HttpClient
  ) { }

}

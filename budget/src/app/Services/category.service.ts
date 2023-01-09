import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  
  readonly V_API = environment.ApiUrl+'/Category';

  constructor(
    private http : HttpClient
  ) { }

}

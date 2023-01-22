import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubCategoryService {

  readonly V_API = environment.ApiUrl+'/SubCategory';

  constructor(
    private http : HttpClient
  ) { }

}

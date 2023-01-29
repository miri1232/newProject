import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../Classes/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  
  readonly V_API = environment.ApiUrl+'/Category';

  constructor(
    private http : HttpClient
  ) { }

  
  GetAllCategory(): Observable<Category[]> {
    const category=new HttpParams();
    
    return this.http.get<Category[]>(this.V_API + '/GetAllCategory');
  }

}

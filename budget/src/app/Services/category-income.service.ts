import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CategoryIncome } from '../Classes/CategoryIncome';
import { SourceOfIncome } from '../Classes/SourceOfIncome';

@Injectable({
  providedIn: 'root'
})
export class CategoryIncomeService {

  readonly V_API = environment.ApiUrl+'/CategoryIncome';

  constructor(
    private http : HttpClient
  ) { }

  GetAllCategory(): Observable<CategoryIncome[]> {
    const categoryIncome=new HttpParams();
    
    return this.http.get<CategoryIncome[]>(this.V_API + '/GetAllCategoryIncome');
  }

  AddCategoryIncome(newCategoryIncome:CategoryIncome):Observable<boolean> {
    return this.http.post<boolean>(this.V_API + '/AddCategoryIncome',newCategoryIncome); 
  }
  
  AddSourceOfIncome(newSourceOfIncome:SourceOfIncome):Observable<boolean> {
    return this.http.post<boolean>(this.V_API + '/AddSourceOfIncome',newSourceOfIncome);
  }
 
  
}

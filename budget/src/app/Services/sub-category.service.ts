import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Subcategory } from '../Classes/Subcategory';

@Injectable({
  providedIn: 'root'
})
export class SubCategoryService {

  readonly V_API = environment.ApiUrl+'/Subcategory';

  constructor(
    private http : HttpClient
  ) { }

  
  GetAllSubcategory(): Observable<Subcategory[]> {
    // const category=new HttpParams();
        return this.http.get<Subcategory[]>(this.V_API + '/GetAllSubcategory');

  }

  GetSubcategoryByCategory(category:number) : Observable<Subcategory[]> {
    const p=new HttpParams().set('category',category);

     return this.http.get<Subcategory[]>(this.V_API + '/GetSubcategoryByCategory',{responseType: 'json',params:p});
   // return this.http.get<Subcategory[]>(this.V_API + '/GetSubcategoryByCategory'+category);

}

AddSubcategory(newSubCategory:Subcategory):Observable<boolean> {
  return this.http.post<boolean>(this.V_API + '/AddSubcategory',newSubCategory);

}

}

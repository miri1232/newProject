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
    const category=new HttpParams();
    
    return this.http.get<Subcategory[]>(this.V_API + '/GetAllSubcategory');
  }

}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Permission } from '../Classes/Permission';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  readonly V_API = environment.ApiUrl+'/Permission';

  constructor(
    private http: HttpClient
  ) { }

  AddPermission(newPermission:Permission ):Observable<boolean> {

    return this.http.post<boolean>(this.V_API + '/AddPermission',newPermission);
}
GetAllPermissionForBudget(idBudget:number):Observable<Permission[]> {

    return this.http.get<Permission[]>(this.V_API + '/GetAllPermissionForBudget');
}







  
}

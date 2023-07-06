import { HttpClient, HttpParams } from '@angular/common/http';
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

GetLevelPermissionForBudgetByID(idBudget:number, idUser:string):Observable<number> {
  const p=new HttpParams().set('idBudget',idBudget).set('id',idUser);

    return this.http.get<number>(this.V_API + '/GetLevelPermissionForBudgetByID',{params:p});

}






  
}

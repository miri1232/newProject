import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class IncomesService {
  readonly V_API = environment.ApiUrl+'/Income';

  constructor(
    private http : HttpClient
  ) { }
}

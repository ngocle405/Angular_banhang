import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LienheService {
  readonly APIUrl="http://localhost:15330/api";

  constructor(private http: HttpClient) { }
  getAll():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/lienhe');
  }
  delete(lh:any){
    return this.http.delete(this.APIUrl+'/lienhe/'+lh);
  }
}

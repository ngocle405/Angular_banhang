import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};
@Injectable({
  providedIn: 'root'
})

export class NhacungcapService {
  readonly APIUrl="http://localhost:15330/api";

  constructor(private http: HttpClient) { }
  getAll():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/nhacungcap');
  }
  getByid(mancc: any): Observable<any> {
    const url = `${this.APIUrl}/nhacungcap/${mancc}`;
    return this.http.get<any>(url);
  }
  add(nhacungcap:any){
    return this.http.post(this.APIUrl+'/nhacungcap',nhacungcap);
  }
  pagination(data: any): Observable<any[]> {
    const url = `${this.APIUrl}/nhacungcap/pagination`;
    var body = JSON.stringify(data);
    return this.http.post<any>(url, body, httpOptions);
  }
  update(nhacungcap:any){
    return this.http.put(this.APIUrl+'/nhacungcap/' ,nhacungcap);
  }
  
  deleteNhacungcap(nhacungcap:any){
    return this.http.delete(this.APIUrl+'/nhacungcap/'+nhacungcap);
  }

}

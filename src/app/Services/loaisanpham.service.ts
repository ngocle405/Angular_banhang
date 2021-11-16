import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaisanphamService {
  readonly APIUrl="http://localhost:15330/api";

  constructor(private http: HttpClient) { }
  getAll():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/loaisanpham');
  }
  getByid(maloai: any): Observable<any> {
    const url = `${this.APIUrl}/loaisanpham/${maloai}`;
    return this.http.get<any>(url);
  }
  add(loaisp:any){
    return this.http.post(this.APIUrl+'/loaisanpham',loaisp);
  }
  // pagination(data: any): Observable<any[]> {
  //   const url = `${this.APIUrl}/nhacungcap/pagination`;
  //   var body = JSON.stringify(data);
  //   return this.http.post<any>(url, body, httpOptions);
  // }
  update(loaisp:any){
    return this.http.put(this.APIUrl+'/loaisanpham/' ,loaisp);
  }
  
  delete(loaisp:any){
    return this.http.delete(this.APIUrl+'/loaisanpham/'+loaisp);
  }

}


import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SanphamService {
  readonly APIUrl="http://localhost:15330/api";
  readonly PhotoUrl = "http://localhost:15330/Photos";
  constructor(private http:HttpClient) { }
  getAll():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/sanpham');
  }
  getByid(masp: any): Observable<any> {
    const url = `${this.APIUrl}/sanpham/${masp}`;
    return this.http.get<any>(url);
  }
  add(val:any){
    return this.http.post(this.APIUrl+'/sanpham',val);
  }
  update(val:any){
    return this.http.put(this.APIUrl+'/sanpham',val);
  }
  delete(val:any){
    return this.http.delete(this.APIUrl+'/sanpham/'+val);
  }
  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/sanpham/SaveFile',val);
  }

  getAllNcc():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/sanpham/GetNcc');
  }
  getAllLoaisp():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/sanpham/GetLoaisp');
  }

}

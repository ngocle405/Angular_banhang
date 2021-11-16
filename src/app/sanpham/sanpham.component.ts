import { Component, OnInit } from '@angular/core';
import { SanphamService } from '../Services/sanpham.service';

@Component({
  selector: 'app-sanpham',
  templateUrl: './sanpham.component.html',
  styleUrls: ['./sanpham.component.css']
})
export class SanphamComponent implements OnInit {

  page: any = 1;
  totalLength: any;

  sanpham: any = [];


  searchText: any;
  //
  id: any;
  tensp: any;
  loaisp: any;
  nhacungcap: any;
  giaban: any;
  gianhap: any;
  soluong: any;
  khungxe: any;
  khoiluong: any;
  dungtichxylanh: any;
  dongco: any;
  muctieuthunguyenlieu: any;
  phuoctruoc: any;
  phuocsau: any;
  docaoyen: any;
  dairongcao: any;
  hopso: any;
  congsuattoida: any;
  tienich: any;
  dungtichbinhxang: any;
  mota: any;
  hinhanh: any;
  mausac: any;
  status: any;
  maloai: any;
  mancc: any;
  baohanh:any;
  PhotoFilePath: any;
  //
  nhacungcapList: any;
  loaispList: any;
  constructor(private sanphamService: SanphamService) { }

  ngOnInit(): void {
    this.refreshSanpham();
    this.sanphamService.getAllLoaisp().subscribe((data: any) => {
      this.loaispList = data;//lay du lieu 
      this.maloai=this.maloai;
    });
    this.sanphamService.getAllNcc().subscribe((data: any) => {
      this.nhacungcapList = data;//lay du lieu 
      this.mancc=this.mancc;
    });

  }
  refreshSanpham() {
    this.sanphamService.getAll().subscribe(data => {
      this.sanpham = data;

      this.totalLength = data.length;
      console.log(this.sanpham);
    });
  }
  //
  public add() {
    var val = {
      id: this.id,
      tensp: this.tensp,
      mancc: this.mancc,
      maloai: this.maloai,
      giaban: this.giaban,
      gianhap: this.gianhap,
      soluong: this.soluong,
      khungxe: this.khungxe,
      khoiluong: this.khoiluong,
      dungtichxylanh: this.dungtichxylanh,
      dongco: this.dongco,
      muctieuthunguyenlieu: this.muctieuthunguyenlieu,
      phuoctruoc: this.phuoctruoc,
      phuocsau: this.phuocsau,
      hinhanh: this.hinhanh,
      mausac: this.mausac,
      docaoyen: this.docaoyen,
      dairongcao: this.dairongcao,
      hopso: this.hopso,
      tienich: this.tienich,
      congsuattoida: this.congsuattoida,
      mota: this.mota,
      dungtichbinhxang: this.dungtichbinhxang,
      baohanh: this.baohanh,

    };
    this.sanphamService.add(val).subscribe(res => {
      alert(res.toString());
      console.log(res);
      location.reload();
    });
  };

  //lấy mã 
  onEdit(masp: any): void {
    this.sanphamService
      .getByid(masp)
      .subscribe({
        next: (sp) => {
          //console.log(supplier);
          this.id = sp.id;
          this.tensp = sp.tensp;
          this.maloai = sp.maloai;
          this.mancc = sp.mancc;
          this.giaban = sp.giaban;
          this.gianhap = sp.gianhap;
          this.soluong = sp.soluong;
          this.khungxe = sp.khungxe;
          this.khoiluong = sp.khoiluong;
          this.dungtichxylanh = sp.dungtichxylanh;
          this.dongco = sp.dongco;
          this.muctieuthunguyenlieu = sp.muctieuthunguyenlieu;
          this.phuocsau = sp.phuocsau;
          this.phuoctruoc = sp.phuoctruoc;
          this.mausac = sp.mausac;
          this.hinhanh = sp.hinhanh;
          this.status = sp.status;
          this.docaoyen = sp.docaoyen;
          this.dairongcao = sp.dairongcao;
          this.hopso = sp.hopso;
          this.congsuattoida = sp.congsuattoida;
          this.dungtichbinhxang = sp.dungtichbinhxang;
          this.tienich = sp.tienich;
          this.mota = sp.mota;
          this.baohanh=sp.baohanh;
          this.PhotoFilePath = this.sanphamService.PhotoUrl + this.hinhanh;
        },

      });
  }
  public update() {
    var val = {
      id: this.id,
      tensp: this.tensp,
      mancc: this.mancc,
      maloai: this.maloai,
      giaban: this.giaban,
      gianhap: this.gianhap,
      soluong: this.soluong,
      khungxe: this.khungxe,
      khoiluong: this.khoiluong,
      dungtichxylanh: this.dungtichxylanh,
      dongco: this.dongco,
      muctieuthunguyenlieu: this.muctieuthunguyenlieu,
      phuoctruoc: this.phuoctruoc,
      phuocsau: this.phuocsau,
      hinhanh: this.hinhanh,
      mausac: this.mausac,
      status: this.status,
      docaoyen: this.docaoyen,
      dairongcao: this.dairongcao,
      hopso: this.hopso,
      tienich: this.tienich,
      mota: this.mota,
      congsuattoida: this.congsuattoida,
      dungtichbinhxang: this.dungtichbinhxang,
      baohanh:this.baohanh

    };
    this.sanphamService.update(val).subscribe(res => {
      alert(res.toString());
      console.log(res);
      window.location.reload();
    });
  };
  deleteClick(item: any) {
    if (confirm('Bạn có muốn xóa ??')) {
      this.sanphamService.delete(item.id).subscribe(data => {
        alert(data.toString());
        this.refreshSanpham();
      });
    }
  }
  closeClick() {

    this.refreshSanpham();
  }
  public uploadPhoto(event: any) {
    var file = event.target.files[0];
    console.log(file)
    const formData: FormData = new FormData();
    formData.append('uploadedFile', file);
    console.log(formData)
    this.sanphamService.UploadPhoto(formData).subscribe((data: any) => {
      this.hinhanh = data.toString();
      this.PhotoFilePath = this.sanphamService.PhotoUrl + this.hinhanh;
    })
  }

}

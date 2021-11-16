import { Component, OnInit } from '@angular/core';
import { LoaisanphamService } from '../Services/loaisanpham.service';

@Component({
  selector: 'app-loaisanpham',
  templateUrl: './loaisanpham.component.html',
  //styleUrls: ['./loaisanpham.component.css']
})
export class LoaisanphamComponent implements OnInit {
  display: any = false;
  page: any = 1;
  totalLength: any;
  ModalTitle: any = "";
  loaisanpham: any = [];
  id: any;
  tenloai: any;
  ngaytao: any;
  status: any;
  //
  searchText: any;
  constructor(private loaisanphamService: LoaisanphamService) { }

  ngOnInit(): void {
    this.loaisanphamList();

  }
  loaisanphamList() {
    this.loaisanphamService.getAll().subscribe(data => {
      this.loaisanpham = data;
      this.totalLength = data.length;
      console.log(this.loaisanpham);
    });
  }
  add() {
    var val = {
      id: this.id,
      tenloai: this.tenloai,
    };
    this.loaisanphamService.add(val).subscribe((data: any) => {
      alert(data.toString());
      location.reload();
    })
  }
  onEdit(maloai: any): void {

    this.loaisanphamService
      .getByid(maloai)

      .subscribe({
        next: (loai) => {
          //console.log(supplier);
          this.id = loai.id;
          this.tenloai = loai.tenloai;
          this.status=loai.status;
        },

      });
  }

  update(){
    var val = {
      id: this.id,
      tenloai: this.tenloai,
      status: this.status
    };
    this.loaisanphamService.update(val).subscribe((data: any) => {
      alert(data.toString());
      location.reload();
    })
  }
  closeClick() {
    this.display = false;
    this.loaisanphamList;
  }
  deleteClick(item: any) {
    if (confirm('Bạn có muốn xóa không ??')) {
      this.loaisanphamService.delete(item.id).subscribe(data => {
        alert(data.toString());
        this.loaisanphamList();
      });
    }
  }

}

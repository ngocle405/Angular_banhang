import { Component, OnInit } from '@angular/core';
import { NhacungcapService } from '../Services/nhacungcap.service';

@Component({
  selector: 'app-nhacungcap',
  templateUrl: './nhacungcap.component.html',
  styleUrls: ['./nhacungcap.component.css'],

})
export class NhacungcapComponent implements OnInit {

  
  checkSearch: boolean = false;
  page: any = 1;
  pageSize: any = 5;
  txtSearchName: any = '';
  sortByName: any = '';
  sortByCreatedDate: any = 'desc';
  totalRecords: any;
  nhacungcap: any = [];

  totalLength: any;
  //
  mancc:any;
  tenncc:any;
  diachi:any;
  email:any;
  dienthoai:any;
  ghichu:any;
  status:any;
  constructor(private nhacungcapService: NhacungcapService) { }

  ngOnInit(): void {

    this.NhacungcapList();
    //this.loadData(1);
  }
  NhacungcapList() {
    this.nhacungcapService.getAll().subscribe(data => {
      this.nhacungcap = data;
      this.totalLength = data.length;
      console.log(this.nhacungcap);
    });
  }
  loadData(page: any): void {
    // this.spinner.show();
    if (this.checkSearch == true) this.page = 1;
    else this.page = page;
    var data = {
      page: this.page,
      pageSize: this.pageSize,
      nameSearch: this.txtSearchName,
      sortByName: this.sortByName,
      sortByCreatedDate: this.sortByCreatedDate,
    }
    setTimeout(() => {
      this.nhacungcapService
        .pagination(data)
        // .pipe(first())
        .subscribe({
          next: (model: any) => {
            this.nhacungcap = model.data;
            this.totalRecords = model.totalItems;
            this.checkSearch = false;
            //  this.spinner.hide();
          },

        });
    }, 300);
  }
  onSearch(): void {
    this.checkSearch = true;
    this.loadData(1);
  }
  //ncc:any;
  public add() {
    var val = {
      tenncc: this.tenncc,
     
      diachi:this.diachi,
      email:this.email,
      dienthoai:this.dienthoai,
    };
    this.nhacungcapService.add(val).subscribe(res => {
      alert(res.toString());
      location.reload();
      this.NhacungcapList();
    });
  }
  
    //lấy mã 
    onEdit(mancc: any): void {
      this.nhacungcapService
        .getByid(mancc)
        .subscribe({
          next: (ncc) => {
            //console.log(supplier);
            this.mancc = ncc.id;
            this.tenncc = ncc.tenncc;
            this.email = ncc.email;
            this.dienthoai = ncc.dienthoai;
            this.diachi = ncc.diachi ;
            this.status=ncc.status;
          },
  
        });
    }
    //sửa
    public update() {
      var val = {
        id: this.mancc,
        tenncc: this.tenncc,
        email: this.email,
        diachi: this.diachi,
        dienthoai: this.dienthoai,
        status:this.status
      };
      this.nhacungcapService.update(val).subscribe(res => {
        alert(res.toString());
        this.NhacungcapList();
        location.reload();
      });
    }

  deleteClick(item: any) {
    if (confirm('Bạn có muốn xóa không ??')) {
      this.nhacungcapService.deleteNhacungcap(item.id).subscribe(data => {
        alert(data.toString());
        this.NhacungcapList();
      })
    }
  }
  closeClick() {
   
    this.NhacungcapList();
  }

}

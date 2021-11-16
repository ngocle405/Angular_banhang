import { Component, OnInit } from '@angular/core';
import { LienheService } from '../Services/lienhe.service';

@Component({
  selector: 'app-lienhe',
  templateUrl: './lienhe.component.html',
  styleUrls: ['./lienhe.component.css']
})
export class LienheComponent implements OnInit {

  constructor(private readonly lienheService: LienheService) { }

  page: any = 1;
  totalLength: any;

  lienhe: any = [];


  searchText: any;
  ngOnInit(): void {
    this.LienheList();
  }
  LienheList() {
    this.lienheService.getAll().subscribe(data => {
      this.lienhe = data;

      this.totalLength = data.length;

    });
  }
  //
  deleteClick(item: any) {
    if (confirm('Bạn có muốn xóa ??')) {
      this.lienheService.delete(item.id).subscribe(data => {
        alert(data.toString());
        this.LienheList();
      });
    }
  }
}

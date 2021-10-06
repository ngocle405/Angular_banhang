import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoaisanphamComponent } from './loaisanpham/loaisanpham.component';
import { NhacungcapComponent } from './nhacungcap/nhacungcap.component';
import { SanphamComponent } from './sanpham/sanpham.component';
import { LoaisanphamService } from './Services/loaisanpham.service';


const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"nhacungcap",component:NhacungcapComponent},
  {path:"sanpham",component:SanphamComponent},
  {path:"loaisanpham",component:LoaisanphamComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

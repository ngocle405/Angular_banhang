
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
// import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { CKEditorModule } from 'ng2-ckeditor';
import { HomeComponent } from './home/home.component';
import { TopbarComponent } from './topbar/topbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { LoaisanphamComponent } from './loaisanpham/loaisanpham.component';
import { NhacungcapComponent } from './nhacungcap/nhacungcap.component';

import { MasterDataComponent } from './nhacungcap/master-data/master-data.component';
import { SanphamComponent } from './sanpham/sanpham.component';
import { PostPutSanphamComponent } from './sanpham/post-put-sanpham/post-put-sanpham.component';
import { PostPutLoaisanphamComponent } from './loaisanpham/post-put-loaisanpham/post-put-loaisanpham.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TopbarComponent,
    SidebarComponent,
    LoaisanphamComponent,
    NhacungcapComponent,
    MasterDataComponent,
    SanphamComponent,
    PostPutSanphamComponent,
    PostPutLoaisanphamComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    CKEditorModule,
    Ng2SearchPipeModule

  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }

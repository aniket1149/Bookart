import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { ShopModule } from '../shop/shop.module';
import { ShopComponent } from '../shop/shop.component';
import { BookItemComponent } from '../shop/book-item/book-item.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    HomeComponent,


  ],
  imports: [
    CommonModule,
    ShopModule,
    RouterModule
  ],
  exports:[
    HomeComponent
  ]
})
export class HomeModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { BookItemComponent } from './book-item/book-item.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    ShopComponent,
    BookItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports:[ShopComponent]
})
export class ShopModule { }

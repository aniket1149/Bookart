import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SellComponent } from './sell.component';
import { SellRoutingModule } from './sell-routing.module';



@NgModule({
  declarations: [
    SellComponent
  ],
  imports: [
    CommonModule,
    SellRoutingModule
  ],exports:[
    SellComponent
  ]
})
export class SellModule { }

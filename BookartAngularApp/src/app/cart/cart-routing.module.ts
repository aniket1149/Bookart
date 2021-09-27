import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './cart.component';
import { ShopComponent } from '../shop/shop.component';

const routes:Routes=[
  {path:'', component:CartComponent},
  {path:'shop/:id', component:ShopComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,

  ],
  exports:[
    RouterModule
  ]
})
export class CartRoutingModule { }

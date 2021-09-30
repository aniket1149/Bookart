import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SellComponent } from './sell.component';

const routes: Routes=[
  {path: '', component: SellComponent},

];

@NgModule({
  declarations: [],
  imports: [

    RouterModule.forChild(routes)
  ], exports:[
    RouterModule
  ]
})
export class SellRoutingModule { }

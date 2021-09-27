import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BookDetailsComponent } from './shop/book-details/book-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {path: '', component:HomeComponent},
  {path: 'shop', loadChildren:()=>import('./shop/shop.module').then(mod=>mod.ShopModule)},
  {path: 'cart', loadChildren:()=>import('./cart/cart.module').then(mod=>mod.CartModule)},
  {path: 'checkout', loadChildren:()=>import('./checkout/checkout.module').then(mod=>mod.CheckoutModule)},
  // {path: 'shop/:id', component: BookDetailsComponent},



  {path: '**', redirectTo: '', pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

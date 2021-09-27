import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICart, ICartItem } from '../shared/models/ICart';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cart$: Observable<ICart>;
  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.cart$=this.cartService.cart$;
  }

  removeBookCartItem(item: ICartItem){
    this.cartService.removeBookFromCart(item);
  }

  incrementBookCartItem(item: ICartItem){
    this.cartService.addIncrementBookQuantity(item);
  }
  decrementBookCartItem(item:ICartItem){
    this.cartService.decrementBookQuantity(item);
  }
}

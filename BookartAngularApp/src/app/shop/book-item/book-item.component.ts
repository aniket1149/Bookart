import { Component, Input, OnInit } from '@angular/core';
import { CartService } from 'src/app/cart/cart.service';
import { IBooks } from 'src/app/shared/models/IBooks';

@Component({
  selector: 'app-book-item',
  templateUrl: './book-item.component.html',
  styleUrls: ['./book-item.component.css']
})
export class BookItemComponent implements OnInit {
  @Input() book : IBooks;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {

  }
  addItemToCart(){
    this.cartService.addItemToCart(this.book);
  }
}
